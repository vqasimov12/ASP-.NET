using Microsoft.EntityFrameworkCore;
using Web_intro.Entities;

namespace Web_intro.Context;

public class AppDbContext:DbContext
{
    public DbSet<Customer>Customers { get; set; }
    public DbSet<Shipper>Shippers{ get; set; }



    public AppDbContext(DbContextOptions options):base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EcommerceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
