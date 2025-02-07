using Web_intro.Context;
using Web_intro.Entities;

namespace Web_intro.Repositories;

public class CustomerRepository(AppDbContext appDbContext) : ICustomerRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public void Add(Customer customer)
    {
        _appDbContext.Add(customer);
        _appDbContext.SaveChanges();
    }

    public void Delete(string id)
    {
        var user = _appDbContext.Customers.FirstOrDefault(x => x.CustomerId == id);
        if (user is null) return;
        _appDbContext.Remove(user);
        _appDbContext.SaveChanges();
    }

    public Customer Get(string id) => _appDbContext.Customers.FirstOrDefault(z => z.CustomerId == id)!;

    public IQueryable<Customer> GetAll() => _appDbContext.Customers;

    public void Update(Customer customer)
    {
        _appDbContext.Update(customer);
        _appDbContext.SaveChanges();
    }
}