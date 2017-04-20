using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Units.Data.Models
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
            return Where(x => !x.IsDone && x.Due < DateTime.UtcNow);
        }
    }

    [Table("Todos")]
    public class Todo : TimeStamps, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public DateTime Due { get; set; }
    }

    public class TodoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public DateTime Due { get; set; }
    }
}
