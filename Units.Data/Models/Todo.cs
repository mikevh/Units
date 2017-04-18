using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Units.Data
{
    public interface ITododRepository : IRepository<Todo>
    {
        IEnumerable<Todo> OverdueTasks();
    }

    public class TodoRepo : Repository<Todo>, ITododRepository
    {

        public TodoRepo(DbContext db) : base(db)
        {
        }

        public IEnumerable<Todo> OverdueTasks()
        {
            return Where(x => x.Id == 0);
        }
    }

    [Table("Todos")]
    public class Todo : TimeStamps, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
