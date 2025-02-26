using Ecommerce.Application.Abstract;
using Ecommerce.Domain.Models;
using Ecommerce.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers;
public class CartController(ICartSessionService sessionService, ICartService cartService, IProductService productService) : Controller
{
    private readonly ICartSessionService _sessionService = sessionService;
    private readonly IProductService _productService = productService;
    private readonly ICartService _cartService = cartService;

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AddToCart(int productId)
    {
        var productToBeAdded = _productService.GetById(productId);
        var cart = _sessionService.GetCart();
        _cartService.AddToCart(cart, productToBeAdded);
        _sessionService.SetCart(cart);
        TempData["message"] = string.Format("Your product, {0} was added successully to cart", productToBeAdded.ProductName);
        return RedirectToAction("Index", "Product");
    }
    public IActionResult List()
    {
        var cart = _sessionService.GetCart();
        var model = new CartListViewModel
        {
            Cart = cart
        };
        return View(model);
    }
    public IActionResult Remove(int productId)
    {
        var cart = _sessionService.GetCart();
        _cartService.RemoveFromCart(cart, productId);
        var product = _productService.GetById(productId);
        TempData["message"] = string.Format("Your product, {0} was removed successully from cart", product.ProductName);
        _sessionService.SetCart(cart);
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Complete()
    {
        var shippingDetailViewModel = new ShippingDetailsViewModel
        {
            ShippingDetails = new ShippingDetails
            {
                Address = string.Empty,
                City = string.Empty,
                Email = string.Empty,
                Firstname = string.Empty,
                Lastname = string.Empty,
                Age = 0
            }
        };
        return View(shippingDetailViewModel);
    }

    [HttpPost]
    public IActionResult Complete(ShippingDetailsViewModel shippingDetailsViewModel)
    {
        if (!ModelState.IsValid)
            return View();
        else
        {
            TempData.Add("message", string.Format("Thank you {0}, your order is in progress", shippingDetailsViewModel.ShippingDetails.Firstname));
            return RedirectToAction("Index", "Product");
        }
    }
}