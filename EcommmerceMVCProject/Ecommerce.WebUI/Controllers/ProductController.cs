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
    public IActionResult Add(int id = -1)
    {
        var model = new ProductAddViewModel();
        model.Categories = _categoryServide.GetAll();
        if (id != -1)
            model.Product = _productService.GetById(id);
        else
            model.Product = new Domain.Entities.Product();
        return View(model);
    }

    [HttpPost]
    public IActionResult Add(ProductAddViewModel model)
    {
        var a = _productService.GetById(model.Product.ProductId);
        if (a != null)
            _productService.Update(model.Product);
        else
            _productService.Add(model.Product);
        return Redirect("/product/Index");
    }

    public IActionResult Delete(int id)
    {
        _productService.Delete(id);
        return Redirect("/product/Index");
    }
}