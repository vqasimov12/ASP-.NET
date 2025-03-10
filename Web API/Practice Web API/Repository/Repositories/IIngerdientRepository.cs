using Domain.Entites;

namespace Repository.Repositories;

public interface IIngerdientRepository
{
    Task AddAsync(Ingredient ingredient);
    Task<bool> Delete(int id);
    Task<bool> Update(Ingredient ingredient);
    Task<Ingredient> GetByIdAsync(int id);
    Task<IQueryable<Ingredient>> GetAllAsync();
}
