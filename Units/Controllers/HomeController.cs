using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Units.Models;

namespace Units.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lazy<UnitOfWork> _uow;

        private UnitOfWork uow => _uow.Value;

        public HomeController()
        {
            _uow = new Lazy<UnitOfWork>(() => new UnitOfWork(new ApplicationDbContext()));
        }

        public async Task<ActionResult> Index()
        {
            var s = await uow.Students.Where().FirstAsync();

            //var student = new Student { Name = "bob" };
            //var course = new Course { Title = "cs 101" };
            //var grade = new Grade { Student = student, Course = course, Letter = "a-" };

            //uow.Grades.Upsert(grade);
            
            //uow.Save();

            return View();
        }
    }
}