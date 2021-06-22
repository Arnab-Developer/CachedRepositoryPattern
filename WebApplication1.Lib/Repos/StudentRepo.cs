using System.Collections.Generic;
using System.Linq;
using WebApplication1.Lib.Abstractions;
using WebApplication1.Lib.Data;
using WebApplication1.Lib.Models;

namespace WebApplication1.Lib.Repos
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentContext _studentContext;

        public StudentRepo(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        IEnumerable<Student> IStudentRepo.GetAllStudents()
        {
            return _studentContext.Students!.OrderBy(s => s.Id).ToList();
        }
    }
}
