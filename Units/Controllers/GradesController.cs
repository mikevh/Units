using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Units.Models;

namespace Units.Controllers
{
    public class GradesController : BaseController<Grade>
    {
        private readonly IStudentRepository _students;
        private readonly ICourseRepository _courses;

        public GradesController(IGradeRepository repo, IStudentRepository students, ICourseRepository courses) : base(repo)
        {
            _students = students;
            _courses = courses;
        }

        protected override async Task SetViewBag()
        {
            ViewBag.CourseId = new SelectList(await _courses.Where().ToListAsync(), "Id", "Title");
            ViewBag.StudentId = new SelectList(await _students.Where().ToListAsync(), "Id", "Name");
        }
    }
}
