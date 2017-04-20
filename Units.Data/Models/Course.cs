using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Units.Data.Models
{
    public interface ICourseRepository : IRepository<Course>
    {
    }

    public class CourseRepo : Repository<Course>, ICourseRepository
    {
        public CourseRepo(DbContext db) : base(db)
        {
        }
    }

    [Table("Courses")]
    public class Course : TimeStamps, IHasId
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Student> Students { get; set; }
    }

    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<StudentDTO> Students { get; set; }
    }
}