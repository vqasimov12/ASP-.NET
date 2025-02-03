using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Abstract;

public interface ICartService
{
    void AddToCart(Cart cart, Product product);
    void RemoveFromCart(Cart cart, int productId);
    List<CartLine> List(Cart cart);
}
