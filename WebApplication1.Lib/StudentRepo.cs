using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Lib
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentContext _studentContext;

        public StudentRepo(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public virtual IEnumerable<Student> GetAllStudents()
        {
            return _studentContext.Students!.OrderBy(s => s.Id).ToList();
        }
    }
}
