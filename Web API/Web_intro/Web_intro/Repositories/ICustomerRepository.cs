using Web_intro.Entities;

namespace Web_intro.Repositories;

public interface ICustomerRepository
{
    void Add(Customer customer);
    void Update(Customer customer);
    void Delete(string id);
    Customer Get(string id);
    IQueryable<Customer> GetAll();
}