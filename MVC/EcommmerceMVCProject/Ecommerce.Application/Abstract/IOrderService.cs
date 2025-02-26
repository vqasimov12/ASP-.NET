using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Abstract;

public interface IOrderService
{
    List<Order>GetAllByCustomerId(string customerId);
}
