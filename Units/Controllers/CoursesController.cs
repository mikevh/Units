using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Units.Data;

namespace Units.Controllers
{
    public class CoursesController : BaseController<Course>
    {
        private readonly ICacher _cacher;

        public CoursesController(ICourseRepository repo, ICacher cacher) : base(repo)
        {
            _cacher = cacher;
        }

        public override async Task<ActionResult> Index()
        {
            var rv = _cacher.Get("Courses.Index()", () => _repo.Where().ToList());

            return View(rv);
        }
    }
}
