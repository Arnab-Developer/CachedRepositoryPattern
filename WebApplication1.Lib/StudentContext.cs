using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Lib
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student>? Students { get; set; }
    }
}
