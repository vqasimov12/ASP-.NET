
using Domain.Entites;

namespace Repository.Repositories;

public interface IDepartmentRepository
{
    Task AddAsync(Department department);
    Task<bool> Delete(int id);
    Task<bool> Update(Department department);
    Task<Department> GetByIdAsync(int id);
    Task<IQueryable<Department>> GetAllAsync();
}
