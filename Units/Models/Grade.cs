using System.Data.Entity;

namespace Units.Models
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

    public class Grade : IHasId
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Letter { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
