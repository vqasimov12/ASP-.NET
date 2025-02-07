using Web_intro.DTOs.CustomerDtos;
using Web_intro.Entities;

namespace Web_intro.Services;

public interface ICustomerService
{
    Customer Add(AddDTO customer);
    bool Update(Customer customer);
    bool Delete(string id);
    Customer Get(string id);
    List<Customer> GetAll();

}
