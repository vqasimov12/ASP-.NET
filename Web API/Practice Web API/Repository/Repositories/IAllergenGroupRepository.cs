using Domain.Entites;

namespace Repository.Repositories;

public interface IAllergenGroupRepository
{
    Task AddAsync(AllergenGroup allergenGroup);
    Task<bool> Delete(int id);
    Task<bool> Update(AllergenGroup allergenGroup);
    Task<AllergenGroup> GetByIdAsync(int id);
    Task<IQueryable<AllergenGroup>> GetAllAsync();
}
