using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.SQLServer.Context;

public class AppDbContext : DbContext
{
    public DbSet<Category>Categories { get; set; }  

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}