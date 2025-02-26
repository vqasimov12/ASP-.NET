using Lesson2_MWC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lesson2_MWC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index(string key = "") => View(await _studentService.GetAllByKey(key));
    }
}
