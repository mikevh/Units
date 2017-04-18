using Units.Models;

namespace Units.Controllers
{
    public class CoursesController : BaseController<Course>
    {
        public CoursesController(ICourseRepository repo) : base(repo)
        {
        }
    }
}
