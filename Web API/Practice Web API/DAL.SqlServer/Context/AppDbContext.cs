using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace DAL.SqlServer.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Department> Departments{ get; set; }
    public DbSet<Ingredient> Ingredients{ get; set; }
    public DbSet<AllergenGroup> AllergenGroups{ get; set; }
    public DbSet<User> Users { get; set; }
}