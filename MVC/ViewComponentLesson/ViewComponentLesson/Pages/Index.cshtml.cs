using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewComponentLesson.Context;
using ViewComponentLesson.Entities;

namespace ViewComponentLesson.Pages;

public class IndexModel(AppDbContext context) : PageModel
{
    private readonly AppDbContext _context = context;
    public string Message{ get; set; }
    public string Info { get; set; }
    public List<Product>Products { get; set; }

    [BindProperty]
    public Product Product { get; set; }
    public void OnGet()
    {
        Products=_context.Products.ToList();
        Message = $"Now date is {DateTime.Now.DayOfWeek}";
    }
    public IActionResult OnPost()
    {
        _context.Products.Add(Product);
        _context.SaveChanges();
        Message = $"{Product.Name } Added successfully";
        return RedirectToPage("Index");
    }

}