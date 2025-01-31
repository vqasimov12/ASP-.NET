using Ecommerce.WebUI.Models;

namespace Ecommerce.WebUI.Services;
public interface ICartSessionService
{
    Cart GetCart();
    void SetCart(Cart cart);
}
