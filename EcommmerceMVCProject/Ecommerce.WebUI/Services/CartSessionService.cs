using Ecommerce.WebUI.Extensions;
using Ecommerce.WebUI.Models;

namespace Ecommerce.WebUI.Services;

public class CartSessionService(IHttpContextAccessor contextAccessor) : ICartSessionService
{
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;

    public Cart GetCart()
    {
        Cart cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>("cart");
        if (cartToCheck == null)
        {
            _contextAccessor.HttpContext.Session.SetObject("cart", new Cart());
            cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>("cart");
        }
        return cartToCheck;
    }

    public void SetCart(Cart cart) => _contextAccessor.HttpContext.Session.SetObject("cart", cart);
}
