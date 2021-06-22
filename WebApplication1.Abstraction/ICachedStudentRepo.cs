using System.Collections.Generic;

namespace WebApplication1.Abstraction
{
    public interface ICachedStudentRepo
    {
        IEnumerable<Student> GetAllStudents();
    }
}
