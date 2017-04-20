using NLog;
using Units.Data.Models;

namespace Units.Controllers
{
    public class CoursesController : BaseController<Course, CourseDTO>
    {
        private readonly ILogger _logger;

        public CoursesController(ICourseRepository repo, ILogger logger) : base(repo)
        {
            _logger = logger;
        }
    }
}
