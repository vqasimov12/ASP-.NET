using Ecommerce.Application.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Ecommerce.WebUI.ViewComponents;

public class CategoryListViewComponent(ICategoryService categotyService) : ViewComponent
{
    private readonly ICategoryService _categoryService = categotyService;
    public ViewViewComponentResult Invoke()
    {
        var model = new CategoryListViewModel()
        {
            Categories = _categoryService.GetAll()
        };
        return View(model);
    }
   
}
