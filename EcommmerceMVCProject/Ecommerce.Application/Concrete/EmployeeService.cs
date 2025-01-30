using Ecommerce.Application.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.DataAccess.Concrete.EFEntityFramework;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Concrete;

public class EmployeeService(IEmployeeDal employeeDal) : IEmployeeService
{
    private readonly IEmployeeDal _employeeDal = employeeDal;

    public void Add(Employee employee)
    {
        _employeeDal.Add(employee);
    }

    public void Delete(int id)
    {
        var employee= _employeeDal.Get(e=> e.EmployeeId == id);
        _employeeDal.Delete(employee);
    }

    public List<Employee> GetAll()
    {
        return _employeeDal.GetList();
    }

    public Employee GetById(int id)
    {
        return _employeeDal.Get(e => e.EmployeeId == id);
    }

    public void Update(Employee employee)
    {
        _employeeDal.Update(employee);
    }
}
