using Ecommerce.Application.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Concrete;

public class OrderService(IOrderDal orderDal) : IOrderService
{
    private readonly IOrderDal _orderDal = orderDal;
    public List<Order> GetAll()=>_orderDal.GetList();
    public Order GetById(int id)=>_orderDal.Get(x => x.OrderId== id);
    public void Add(Order order)=> _orderDal.Add(order);
    public void Update(Order order)=>_orderDal.Update(order);
    public void Delete(int id)
    {
        var order = _orderDal.Get(x => x.OrderId == id);
        _orderDal.Delete(order);
    }
    public List<Order> GetAllByCustomerId(string userId)=> _orderDal.GetList(x => x.CustomerId == userId);
}