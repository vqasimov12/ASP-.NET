using Ecommerce.Application.Abstract;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Concrete;
public class CartService : ICartService
{
    public void AddToCart(Cart cart, Product product)
    {
        CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId)!;
        if (cartLine != null)
            cartLine.Quantity++;
        else
            cart.CartLines.Add(new CartLine { Quantity = 1, Product = product });
    }

    public List<CartLine> List(Cart cart) => cart.CartLines;
    public void RemoveFromCart(Cart cart, int productId) => cart.CartLines.Remove(cart.CartLines.FirstOrDefault(x => x.Product.ProductId == productId)!);
}