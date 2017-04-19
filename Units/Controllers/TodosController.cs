using Units.Data;
using Units.Data.Models;

namespace Units.Controllers
{
    public class TodosController : BaseController<Todo>
    {
        public TodosController(ITododRepository repo) : base(repo)
        {
        }
    }
}
