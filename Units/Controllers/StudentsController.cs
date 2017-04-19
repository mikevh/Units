using Units.Data;
using Units.Data.Models;

namespace Units.Controllers
{
    public class StudentsController : BaseController<Student>
    {
        public StudentsController(IStudentRepository repo) : base(repo)
        {
        }
    }
}
