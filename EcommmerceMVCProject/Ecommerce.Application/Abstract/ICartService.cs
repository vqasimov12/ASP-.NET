using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Abstract;

public interface ICartService
{
    void AddToCart(Cart cart, Product product);
    void RemoveFromCart(Cart cart, Product product);
    List<CartLine> List(Cart cart);
}
