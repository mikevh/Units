using Units.Data.Models;

namespace Units.Controllers
{
    public class TodosController : BaseController<Todo, TodoDTO>
    {
        public TodosController(ITododRepository repo) : base(repo)
        {
        }
    }
}
