using Ecommerce.Application.Abstract;
using Ecommerce.Application.Concrete;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.DataAccess.Concrete.EFEntityFramework;
using Ecommerce.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//var a = new SessionOptions();
//a.IdleTimeout =TimeSpan.FromSeconds(1000);
//builder.Services.AddSession(a);
builder.Services.AddSession();
var conn = builder.Configuration.GetConnectionString("DefaulConnetion");
builder.Services.AddDbContext<NortWindDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryServic>();


var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Category}/{action=Index}/{id?}");

app.Run();
