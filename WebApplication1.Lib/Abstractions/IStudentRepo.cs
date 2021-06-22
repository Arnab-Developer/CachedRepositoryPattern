using System.Collections.Generic;
using WebApplication1.Lib.Models;

namespace WebApplication1.Lib.Abstractions
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAllStudents();
    }
}
