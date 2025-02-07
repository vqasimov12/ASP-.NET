using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ViewComponentLesson.Context;
using ViewComponentLesson.Entities;

namespace ViewComponentLesson.ViewComponents
{
    public class CategoryListViewComponent(AppDbContext context) : ViewComponent
    {
        private readonly AppDbContext _context = context;
        public ViewViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel
            {
                Categories=_context.Categories.ToList(),

            });
        }
    }
}
