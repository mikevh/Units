using System.Data.Entity;

namespace Units.Data
{
    public class UnitsDbContext : DbContext
    {
        public UnitsDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
