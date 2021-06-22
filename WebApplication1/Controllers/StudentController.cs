using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Lib.Abstractions;
using WebApplication1.Lib.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ICachedStudentRepo _cachedStudentRepo;

        public StudentController(ICachedStudentRepo cachedStudentRepo)
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
