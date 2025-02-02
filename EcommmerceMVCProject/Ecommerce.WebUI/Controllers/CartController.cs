using Ecommerce.Application.Abstract;
using Ecommerce.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers;
public class CartController(ICartSessionService sessionService, IProductService productService) : Controller
{
    private readonly ICartSessionService _sessionService = sessionService;
    private readonly IProductService _productService;

    public IActionResult Index()
    {
        return View();
    }
}