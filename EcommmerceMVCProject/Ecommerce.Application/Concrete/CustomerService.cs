using Ecommerce.Application.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Concrete;

public class CustomerService(ICustomerDal customerDal) : ICustomerService
{
    private readonly ICustomerDal _customerDal = customerDal;
    public List<Customer> GetAll()=>_customerDal.GetList();
    public Customer GetById(string id) => _customerDal.Get(c => c.CustomerId == id);
    public void Add(Customer customer) => _customerDal.Add(customer);
    public void Update(Customer customer) => _customerDal.Update(customer);
    public void Delete(string id)
    {
        var customer = _customerDal.Get(c => c.CustomerId == id);
        _customerDal.Delete(customer);
    }
}
