using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Units.Data
{
    public interface IGradeRepository : IRepository<Grade>
    {
    }

    public class GradeRepo : Repository<Grade>, IGradeRepository
    {

        public GradeRepo(DbContext db) : base(db)
        {
        }
    }

    [Table("Grades")]
    public class Grade : TimeStamps, IHasId
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [Required, MaxLength(2)]
        public string Letter { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
