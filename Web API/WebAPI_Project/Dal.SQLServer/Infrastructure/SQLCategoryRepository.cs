using Dal.SQLServer.Context;
using Dapper;
using Domain.Entities;
using Repository.Repositories;

namespace Dal.SQLServer.Infrastructure;

public class SQLCategoryRepository : BaseSQLRepository, ICategoryRepository
{
    private readonly AppDbContext _context;

    public SQLCategoryRepository(string connnectionString, AppDbContext context) : base(connnectionString)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        var sql = @"
            INSERT INTO CATEGORIES([Name], [CreatedBy])
            VALUES(@Name,@CreatedBy)";
        using var connection = OpenConnection();
        var generatedId = await connection.ExecuteScalarAsync<int>(sql, category);

    }

    public IQueryable<Category> GetAll() => _context.Categories.OrderBy(o => o.CreatedDate).Where(o => o.IsDeleted == false);

    public async Task<Category> GetByIdAsync(int id)
    {
        var sql = @"SELECT c.*
                    FROM CATEGORIES c
                    WHERE c.Id=@id AND c.isDeleted=0";
        using var connection = OpenConnection();
        return await connection.QueryFirstOrDefaultAsync<Category>(sql, id);
    }

    public async Task<IEnumerable<Category>> GetByNameAsync(string name)
    {
        var sql = @"
                DECLARE @searchtext NVARCHAR(max)
                SET @searchtext ='%'+@name+'%'
                SELECT c.*FROM CATEGORIES
                c.[Name] LIKE @searchtext AND c.IsDeleted=0";
        using var connection = OpenConnection();
        return await connection.QueryAsync<Category>(sql, name);
    }

    public async Task<bool> Remove(int id, int deletedBy)
    {
        var checkSql = "SELECT Id FROM WHERE Id=@Id AND IsDeleted=0";
        var sql = @"
                UPDATE CATEGORIES
                SET IsDeleted=1,
                DeletedBy=@deletedBy,
                DeletedDate=GETDATE()
                WHERE Id=@id";

        using var connection = OpenConnection();
        using var transaction = connection.BeginTransaction();
        var categoryId = await connection.ExecuteScalarAsync<int?>(checkSql, id, transaction);
        if (!categoryId.HasValue)
            return false;
        var affectedRow = await connection.ExecuteAsync(sql, new { id, deletedBy }, transaction);
        transaction.Commit();
        return affectedRow > 0;
    }

    public async Task Update(Category category)
    {
        var sql = @"UPDATE CATEGORIES
                    SET Name=@Name, UpdatedBy=@UpdatedBy, UpdatedDate=GETDATE()
                    WHERE Id=@Id";
        using var connection = OpenConnection();
        await connection.QueryAsync<Category>(sql, category);
    }
}
