using Microsoft.EntityFrameworkCore;
using WebApplication1.Lib.Models;

namespace WebApplication1.Lib.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student>? Students { get; set; }
    }
}
