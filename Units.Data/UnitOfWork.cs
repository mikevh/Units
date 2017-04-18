using System;
using System.Data.Entity;

namespace Units.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        ICourseRepository Courses { get; }
        IGradeRepository Grades { get; }
        ITododRepository Todos { get; }

        int Save();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _db;
        private readonly ICacher _cacher;

        private IStudentRepository students;
        private ICourseRepository courses;
        private ITododRepository todos;
        private IGradeRepository grades;
        
        public UnitOfWork(DbContext db, ICacher cache)
        {
            _cacher = cache;
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
