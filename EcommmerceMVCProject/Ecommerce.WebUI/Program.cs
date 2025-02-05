using Ecommerce.Application.Abstract;
using Ecommerce.Application.Concrete;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.DataAccess.Concrete.EFEntityFramework;
using Ecommerce.WebUI.Entities;
using Ecommerce.WebUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<NortWindDbContext>(opt =>
//{
//    opt.UseSqlServer(conn);
//});


builder.Services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer(conn));

builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryServic>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDal, EFProductDal>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDal, EFOrderDal>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerDal, EFCustomerDal>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierDal, EFSupplierDal>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeDal, EFEmployeeDal>();
builder.Services.AddSingleton<ICartSessionService, CartSessionService>();
builder.Services.AddScoped<ICartService, CartService>();

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
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();
