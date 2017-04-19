using System;
using System.Data.Entity;
using Units.Data.Models;

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

        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
    }
}
