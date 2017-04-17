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
        private readonly IUnitOfWork _uow;

        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ActionResult> Index()
        {
            var s = await _uow.Students.Where().FirstAsync();

            //var student = new Student { Name = "bob" };
            //var course = new Course { Title = "cs 101" };
            //var grade = new Grade { Student = student, Course = course, Letter = "a-" };

            //uow.Grades.Upsert(grade);
            
            //uow.Save();

            return View();
        }
    }
}