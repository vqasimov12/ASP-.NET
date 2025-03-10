using Domain.Entites;

namespace Repository.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<bool> Update(Product product);
    Task<bool> Delete(int id,int deletedBy);
    Task<Product> GetByIdAsync(int id);
    Task<IQueryable> GetAllAsync();
}
