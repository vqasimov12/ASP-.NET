using Repository.Repositories;

namespace Repository.Common;

public interface IUnitOfWork
{
    public ICategoryRepository CategoryRepository { get; }
    public IUserRepository UserRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IDepartmentRepository DepartmentRepository { get; }
    public IIngerdientRepository IngerdientRepository { get; }
    public IAllergenGroupRepository AllergenGroupRepository { get; }

    Task<int> SaveChanges();
}