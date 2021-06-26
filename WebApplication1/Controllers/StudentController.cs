using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Lib;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _cachedStudentRepo;

        public StudentController(IStudentRepo cachedStudentRepo)
        {
            _cachedStudentRepo = cachedStudentRepo;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _cachedStudentRepo.GetAllStudents();
        }
    }
}
