using System;
using System.Data.Entity;

namespace Units.Data
{
    public class UnitsDbContext : DbContext
    {
        public UnitsDbContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
