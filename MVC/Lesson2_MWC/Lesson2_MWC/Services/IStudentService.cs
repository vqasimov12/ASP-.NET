using Lesson2_MWC.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson2_MWC.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllByKey(string key = "");
    }
}
