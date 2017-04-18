using Units.Models;

namespace Units.Controllers
{
    public class StudentsController : BaseController<Student>
    {
        public StudentsController(IStudentRepository repo) : base(repo)
        {
        }
    }
}
