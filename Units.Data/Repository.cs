using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Units.Data
{
    public interface IRepository<T>
    {
        Task<T> Find(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate = null);
        void Upsert(T obj);
        Task Delete(int id);
        Task<int> Save();
    }

    public class Repository<T> : IRepository<T> where T : class, IHasId
    {
        internal DbContext _db;
        internal DbSet<T> _set;

        public Repository(DbContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? _set.Where(predicate) : _set;
        }

        public virtual async Task<T> Find(int id)
        {
            return await _set.FindAsync(id);
        }

        public virtual void Upsert(T obj)
        {
            if(obj.Id == default(int))
            {
                var ts = obj as IHasTimeStamps;
                if(ts != null)
                {
                    ts.CreatedOn = DateTime.UtcNow;
                }
                _set.Add(obj);
            }
            else
            {
                var ts = obj as IHasTimeStamps;
                if (ts != null)
                {
                    ts.UpdatedOn = DateTime.UtcNow;
                }
                _db.Entry(obj).State = EntityState.Modified;
            }
        }

        public virtual async Task<int> Save()
        {
            return await _db.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            var obj = await Find(id);
            if(obj != null)
            {
                _set.Remove(obj);
            }
        }
    }
}
