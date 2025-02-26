using Lesson2_MWC.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson2_MWC.Context
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student>Students { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
    }
}