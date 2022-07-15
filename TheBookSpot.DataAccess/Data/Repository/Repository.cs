using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookSpot.DataAccess.Data.Repository.IRepository;

namespace TheBookSpot.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
     
        }

        public IEnumerable<T> GetAllCategory(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string includeProperty = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperty != null)
            {
                foreach (var IncludeProp in includeProperty.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncludeProp);
                }
            }
            if (OrderBy != null)
            {
                return OrderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public T GetFirstORDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, string includeProperty = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperty != null)
            {
                foreach (var IncludeProp in includeProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncludeProp);
                }
            }
           
            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
         T entity = dbSet.Find(id);
            dbSet.Remove(entity);

        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
