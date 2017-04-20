using Units.Data.Models;

namespace Units.Controllers
{
    public class StudentsController : BaseController<Student, StudentDTO>
    {
        public StudentsController(IStudentRepository repo) : base(repo)
        {
        }
    }
}
