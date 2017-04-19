using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Units.Data;
using Units.Data.Models;

namespace Units.Controllers
{
    public class GradesController : BaseController<Grade>
    {
        private readonly IStudentRepository _students;
        private readonly ICourseRepository _courses;
        private readonly IGradeRepository _gradeRepository;

        public GradesController(IGradeRepository repo, IStudentRepository students, ICourseRepository courses) : base(repo)
        {
            _gradeRepository = repo;
            _students = students;
            _courses = courses;
        }

        protected override async Task SetViewBag()
        {
            ViewBag.CourseId = new SelectList(await _courses.Where().ToListAsync(), "Id", "Title");
            ViewBag.StudentId = new SelectList(await _students.Where().ToListAsync(), "Id", "Name");
        }

        public override async Task<ActionResult> Index()
        {
            var rv = _gradeRepository.Where().Include(x => x.Course).Include(x => x.Student);
            return View(rv);
        }
    }
}
