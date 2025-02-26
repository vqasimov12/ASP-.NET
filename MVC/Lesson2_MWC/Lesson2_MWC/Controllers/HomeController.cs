using Lesson2_MWC.Entities;
using Lesson2_MWC.Models;
using Lesson2_MWC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Linq;

namespace Lesson2_MWC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculate _calculate;

        public HomeController(ICalculate calculate)
        {
            _calculate = calculate;
        }

        public string Index() => $"Hello from index action {_calculate.Calculate(100)}";

        public IActionResult Index2() => View();

        public IActionResult Employee1()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                Id = 1,
                Cityİd=1,
                Lastname="Qasimov",
                Firstname="Vaqif"
                },
              new Employee
              {
                Id = 2,
                Cityİd=2,
                Lastname="Huseynli",
                Firstname="Ahmad"
                },
              new Employee
              {
                Id = 3,
                Cityİd=3,
                Lastname="Amirli",
                Firstname="Mirtalib"
                }
           };
            return View(employees);
        }

        //public IActionResult Employee2()
        //{
        //    List<Employee> employees = new List<Employee>()
        //    {
        //        new Employee
        //        {
        //        Id = 1,
        //        Cityİd=1,
        //        Lastname="Qasimov",
        //        Firstname="Vaqif"
        //        },
        //      new Employee
        //      {
        //        Id = 2,
        //        Cityİd=2,
        //        Lastname="Huseynli",
        //        Firstname="Ahmad"
        //        },
        //      new Employee
        //      {
        //        Id = 3,
        //        Cityİd=3,
        //        Lastname="Amirli",
        //        Firstname="Mirtalib"
        //        }
        //   };
        //    return View(employees);
        //}

        public ViewResult Employee2()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                Id = 1,
                Cityİd=1,
                Lastname="Qasimov",
                Firstname="Vaqif"
                },
              new Employee
              {
                Id = 2,
                Cityİd=2,
                Lastname="Huseynli",
                Firstname="Ahmad"
                },
              new Employee
              {
                Id = 3,
                Cityİd=3,
                Lastname="Amirli",
                Firstname="Mirtalib"
                }
           };

            List<string> cities = new List<string>() { "Baku", "Berlin", "Toronto" };
            var vm = new EmploeeViewModel { Cities = cities, Employees = employees };


            return View(vm);
        }

        public IActionResult index4() => Ok();

        public IActionResult index5() => NotFound();

        public IActionResult index6() => BadRequest();

        public IActionResult index7() => Redirect("/home/Index2");

        public IActionResult index8() => RedirectToAction("employee1");

        public IActionResult index9()
        {
            var routeValue = new RouteValueDictionary(
                new { action = "Employee1", controller = "Home" });
            return RedirectToRoute(routeValue);
        }

        public JsonResult index10()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                Id = 1,
                Cityİd=1,
                Lastname="Qasimov",
                Firstname="Vaqif"
                },
              new Employee
              {
                Id = 2,
                Cityİd=2,
                Lastname="Huseynli",
                Firstname="Ahmad"
                },
              new Employee
              {
                Id = 3,
                Cityİd=3,
                Lastname="Amirli",
                Firstname="Mirtalib"
                }
           };
            return Json(employees);
        }

        public JsonResult index11(int id = -1) 
            //route param https://localhost:5001/Home/index11/2
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                Id = 1,
                Cityİd=1,
                Lastname="Qasimov",
                Firstname="Vaqif"
                },
              new Employee
              {
                Id = 2,
                Cityİd=2,
                Lastname="Huseynli",
                Firstname="Ahmad"
                },
              new Employee
              {
                Id = 3,
                Cityİd=3,
                Lastname="Amirli",
                Firstname="Mirtalib"
                }
           };

            if (id == -1)
                return Json(employees);
            else
            {
                var data = employees.FirstOrDefault(e => e.Id == id);

                return Json(data);
            }
        }

        public JsonResult index12(string key, int id = -1)
            //Query param https://localhost:5001/Home/index12?key=if&id=2
        {
            List<Employee> employees = new List<Employee>()
    {
        new Employee
        {
        Id = 1,
        Cityİd=1,
        Lastname="Qasimov",
        Firstname="Vaqif"
        },
      new Employee
      {
        Id = 2,
        Cityİd=2,
        Lastname="Huseynli",
        Firstname="Ahmad"
        },
      new Employee
      {
        Id = 3,
        Cityİd=3,
        Lastname="Amirli",
        Firstname="Mirtalib"
        }
   };
            if (id == -1)
                return Json(employees.Where(e => e.Firstname.Contains(key)));
            else
                return Json(employees.Where(e => e.Firstname.Contains(key) || e.Id == id));
        }

    }
}
