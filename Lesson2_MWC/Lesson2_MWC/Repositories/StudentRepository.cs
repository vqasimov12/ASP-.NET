using Lesson2_MWC.Context;
using Lesson2_MWC.Entities;
using Lesson2_MWC.Repostories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson2_MWC.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            _context.Students.Add(student); 
            _context.SaveChanges();
        }

        public async Task<List<Student>> GetAll()
        {
           return await _context.Students.ToListAsync();
        }
    }
}
