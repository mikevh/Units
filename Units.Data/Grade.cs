using System.ComponentModel.DataAnnotations;
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

    public class Grade : TimeStamps, IHasId
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [Required, MaxLength(2)]
        public string Letter { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
