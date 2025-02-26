using Ecommerce.Application.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        public IActionResult Index()
        {
            var _category = _categoryService.GetAll();
            return Ok(_category);
        }


    }
}
