using Microsoft.EntityFrameworkCore;
using ViewComponentLesson.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opt => { opt.UseSqlServer(conn); });

builder.Services.AddRazorPages();

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
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists?}/{controller=Home}/{action=Index}/{id?}");

app.Run();
