using Dal.SQLServer.Context;
using Dal.SQLServer.Infrastructure;
using Repository.Common;
using Repository.Repositories;

namespace Dal.SQLServer.UnitOfWork;

public class SQLUnitOfWork(string connectionString, AppDbContext appDbContext) : IUnitOfWork
{
    private readonly string _connectionString = connectionString;
    private readonly AppDbContext _appDbContext = appDbContext; 
    public SQLCategoryRepository _sqlCategoryRepository;

    public ICategoryRepository CategoryRepository => _sqlCategoryRepository ?? new SQLCategoryRepository(_connectionString, _appDbContext);

    public async Task<int> SaveChnages() => await _appDbContext.SaveChangesAsync();
}