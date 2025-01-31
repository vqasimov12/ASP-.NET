using Ecommerce.Application.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers;

public class ProductController(IProductService productService, ICategoryService categoryServide) : Controller
{
    private readonly IProductService _productService = productService;
    private readonly ICategoryService _categoryServide = categoryServide;

    public IActionResult Index(int page = 1, int categoryId = 0)
    {
        int pageSize = 10;
        var products = _productService.GetAllByCategory(categoryId);
        var pagedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        var model = new ProductListViewModel()
        {
            Products = pagedProducts,
            CurrentCategory = categoryId,
            PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
            PageSize = pageSize,
            CurrentPage = page
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var model = new ProductAddViewModel();
        model.Product = new Domain.Entities.Product();
        model.Categories = _categoryServide.GetAll();
        return View(model);
    }

    [HttpPost]
    public IActionResult Add(ProductAddViewModel model)
    {
        _productService.Add(model.Product);
        return Redirect("/product/Index");
    }
}