using System.Collections.Generic;
using System.Data.Entity;

namespace Units.Data.Models
{
    public interface IStudentRepository : IRepository<Student>
    {
    }

    public class StudentRepo : Repository<Student>, IStudentRepository
    {
        public StudentRepo(DbContext db) : base(db)
        {
        }
    }

    public class Student : TimeStamps, IHasId
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Grade> Grades { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
