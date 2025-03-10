using Dapper;
using Domain.Entites;
using Repository.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DAL.SqlServer.Infrastructure;

public class SqlProductRepository(string connectionString) : BaseSqlRepository(connectionString), IProductRepository
{
    public async Task AddAsync(Product product)
    {
        var sql = @"INSERT INTO Products([Name],[CreatedBy],[Type],[Barcode],[Price],[OpenCode],
                    [ButtonColor],[TextColor],[InvoiceNumber])
                    VALUES(@Name , @CreatedBy,@Type,@Barcode,@Price,@OpenCode,@ButtonColor,@TextColor,@InvoiceNumber); SELECT SCOPE_IDENTITY()";

        using var conn = OpenConnection();
        using var transaction = conn.BeginTransaction();

        var productId = await conn.ExecuteScalarAsync<int?>(sql, product, transaction);

        foreach (var item in product.IngredientsId)
        {
            var addIngredient = @$"INSERT INTO ProductIngredients([IngredientId],[ProductId]) 
                              VALUES(@item,@productId)";
            conn.Execute(sql, new { item, productId }, transaction);
        }

        foreach (var item in product.DepartmentsId)
        {
            var addIngredient = @$"INSERT INTO ProductDepartments([DepartmentId],[ProductId]) 
                              VALUES(@item,@productId)";
            conn.Execute(sql, new { item, productId }, transaction);
        }

        foreach (var item in product.AllergenGroupId)
        {
            var addIngredient = @$"INSERT INTO ProductAllergenGroups([AllergenGroupId],[ProductId]) 
                  VALUES(@item,@productId)";
            conn.Execute(sql, new { item, productId }, transaction);
        }

        transaction.Commit();
    }

    public async Task<bool> Delete(int id, int deletedBy)
    {
        var sql = @"UPDATE Products
                    SET IsDeleted = 1,
                    DeletedBy = @deletedBy,
                    DeletedDate = GETDATE()
                    WHERE Id = @Id and IsDeleted=0";

        var conn = OpenConnection();
        var transaction = conn.BeginTransaction();

        var affectedRow = conn.Execute(sql, new { id, deletedBy }, transaction);

        var ingredientTransaction = @"UPDATE ProductIngredients
                                      SET IsDeleted = 1,
                                      WHERE ProductId = @Id and IsDeleted=0 
                                      ";

        conn.Execute(ingredientTransaction, new { id }, transaction);

        var departmentTransaction = @"UPDATE ProductDepartments
                                      SET IsDeleted = 1,
                                      WHERE ProductId = @Id  and IsDeleted=0
                                      ";

        conn.Execute(departmentTransaction, new { id }, transaction);


        var allergenTransaction = @"UPDATE ProductAllergenGroups
                                      SET IsDeleted = 1,
                                      WHERE ProductId = @Id  and IsDeleted=0
                                      ";

        conn.Execute(allergenTransaction, new { id }, transaction);

        return affectedRow > 0;

    }

    public async Task<IQueryable> GetAllAsync()
    {
        var conn = OpenConnection();

        var sql = "SELECT * FROM Products AS P WHERE P.IsDeleted=0";
        var products = await conn.QueryAsync<Product>(sql);
        return products.AsQueryable();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var sql = @"SELECT *
                    FROM Categories AS P
                    WHERE P.Id = @id AND P.IsDeleted =0";

        using var conn = OpenConnection();

        return await conn.QueryFirstOrDefaultAsync<Product>(sql, new { id })!;
    }

    public async Task<bool> Update(Product product)
    {

        var sql = @"UPDATE Products
                    SET [Name]=@Name ,
                    [Type]=@Type,
                    [Barcode]=@Barcode,
                    [Price]=@Price,
                    [OpenCode]=@OpenCode,
                    [ButtonColor]=@ButtonColor,
                    [TextColor]=@TextColor,
                    [InvoiceNumber]=@InvoiceNumber,
                    UpdatedBy = @UpdatedBy,
                    UpdatedDate = GETDATE(),
                    WHERE Id = @Id and IsDeleted=0";

        using var conn = OpenConnection();
        using var transaction = conn.BeginTransaction();

        conn.Query(sql, product, transaction);

        foreach (var item in product.IngredientsId)
        {
            var addIngredient = @$"INSERT INTO ProductIngredients([IngredientId],[ProductId]) 
                              VALUES(@{item},@{productId})";
            conn.Execute(sql, new { item, productId }, transaction);
        }

        foreach (var item in product.DepartmentsId)
        {
            var addIngredient = @$"INSERT INTO ProductDepartments([DepartmentId],[ProductId]) 
                              VALUES(@{item},@{productId})";
            conn.Execute(sql, new { item, productId }, transaction);
        }

        foreach (var item in product.AllergenGroupId)
        {
            var addIngredient = @$"INSERT INTO ProductAllergenGroups([AllergenGroupId],[ProductId]) 
                  VALUES(@{item},@{productId})";
            conn.Execute(sql, new { item, productId }, transaction);
        }

        transaction.Commit();
    }
}
