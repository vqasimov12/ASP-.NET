using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("age", 25);
            HttpContext.Session.SetString("Name", "Jhon Soprano");
            return View();
        }

        public string GetSession()
        {
            return $"Age {HttpContext.Session.GetInt32("age")} Name {HttpContext.Session.GetString("Name")}";
        }


    }
}
