using Ecommerce.Application.Abstract;
using Ecommerce.Application.Concrete;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.DataAccess.Concrete.EFEntityFramework;
using Ecommerce.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
var conn = builder.Configuration.GetConnectionString("DefaulConnection");
builder.Services.AddDbContext<NortWindDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryServic>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDal, EFProductDal>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
