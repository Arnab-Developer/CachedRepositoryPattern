using System.Collections.Generic;

namespace WebApplication1.Lib
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAllStudents();
    }
}
