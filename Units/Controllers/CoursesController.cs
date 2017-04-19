using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using NLog;
using Units.Data;

namespace Units.Controllers
{
    public class CoursesController : BaseController<Course>
    {
        private readonly ICacher _cacher;
        private readonly ILogger _logger;

        public CoursesController(ICourseRepository repo, ICacher cacher, ILogger logger) : base(repo)
        {
            _logger = logger;
            _cacher = cacher;
        }

        public override async Task<ActionResult> Index()
        {
            var sw = Stopwatch.StartNew();
            var rv = _cacher.Get("Courses.Index()", () => _repo.Where().ToList());
            sw.Stop();
            _logger.Trace($"CoursesController.Index() => {rv.Count} records in {sw.ElapsedMilliseconds}ms");

            return View(rv);
        }
    }
}
