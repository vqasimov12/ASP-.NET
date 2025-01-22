using Microsoft.AspNetCore.Mvc;
using ViewComponentLesson.Context;

namespace ViewComponentLesson.Controllers
{
    public class HomeController(AppDbContext _context) : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Categories() => Json(_context.Categories);
    }
}