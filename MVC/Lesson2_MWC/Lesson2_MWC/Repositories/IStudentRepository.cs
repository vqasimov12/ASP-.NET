using Lesson2_MWC.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson2_MWC.Repostories
{
    public interface IStudentRepository
    {
        Task<List<Student>>GetAll();
        void Add(Student student);
    }
}
