using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Units.Data
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
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}