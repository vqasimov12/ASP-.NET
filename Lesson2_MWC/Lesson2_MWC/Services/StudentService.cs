using Lesson2_MWC.Entities;
using Lesson2_MWC.Repostories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2_MWC.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public async Task<List<Student>> GetAllByKey(string key = "")
        {
            var data = await _studentRepository.GetAll();
            return key != "" ?
                data.Where(s => s.Firstname.ToLower().Contains(key.ToLower())).ToList() : data;
        }
    }
}
