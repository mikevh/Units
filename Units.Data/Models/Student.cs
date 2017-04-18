using System.Collections.Generic;
using System.Data.Entity;

namespace Units.Data
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
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Grade> Grades { get; set; }
        public ICollection<Course> Course { get; set; }
    }
}
