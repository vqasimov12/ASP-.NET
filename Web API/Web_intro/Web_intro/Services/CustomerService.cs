using Web_intro.DTOs.CustomerDtos;
using Web_intro.Entities;
using Web_intro.Repositories;

namespace Web_intro.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public Customer Add(AddDTO customer)
    {
        Customer customerCopy = new Customer
        {
            CustomerId = customer.CustomerId,
            CompanyName = customer.CustomerName,
        };
        _customerRepository.Add(customerCopy);
        return customerCopy;
    }

    public bool Delete(string id)
    {
        _customerRepository.Delete(id);
        return true;
    }

    public Customer Get(string id) => _customerRepository.Get(id);

    public List<Customer> GetAll() => [.. _customerRepository.GetAll()];

    public bool Update(Customer customer)
    {
        _customerRepository.Update(customer);
        return true;
    }
}
