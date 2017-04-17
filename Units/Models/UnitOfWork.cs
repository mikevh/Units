using System;

namespace Units.Models
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _db;

        private IStudentRepository students;
        private ICourseRepository courses;
        private ITododRepository todos;
        private IGradeRepository grades;
        
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public IStudentRepository Students => students = students ?? new StudentRepo(_db);
        public ICourseRepository Courses => courses = courses ?? new CourseRepo(_db);
        public ITododRepository Todos => todos = todos ?? new TodoRepo(_db);
        public IGradeRepository Grades => grades = grades ?? new GradeRepo(_db);

        public int Save()
        {
            var rv = _db.SaveChanges();
            return rv;
        }

        private bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
