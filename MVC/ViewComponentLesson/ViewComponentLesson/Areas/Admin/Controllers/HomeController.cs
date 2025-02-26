using Microsoft.AspNetCore.Mvc;

namespace ViewComponentLesson.Areas.Admin.Controllers;
public class HomeController : Controller
{
    [Area("admin")]
    public IActionResult Index()
    {
        return View();
    }
}