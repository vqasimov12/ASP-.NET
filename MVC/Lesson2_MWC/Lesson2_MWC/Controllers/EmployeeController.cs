using Lesson2_MWC.Entities;
using Lesson2_MWC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson2_MWC.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            var vm = new EmployeeAddViewModel()
            {
                Employee = new Employee(),
                Cities = new()
                {
                    new SelectListItem(){Text="Baku",Value="10"},
                    new SelectListItem(){Text="Sumgayit",Value="50"},
                    new SelectListItem(){Text="Agdam",Value="02"},
                    new SelectListItem(){Text="Masalli",Value="44"}
                }
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(EmployeeAddViewModel viewModel)
        {
            if (ModelState.IsValid)
                return Redirect("/home/index");
            else return View(viewModel);
        }
    }
}
