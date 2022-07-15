using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TheBookSpot.DataAccess.Data.Repository.IRepository
{
     public interface IRepository<T> where T :class
    {
        T GetById( int id);
        IEnumerable<T> GetAllCategory( Expression<Func<T,bool>> filter = null , Func<IQueryable<T>,IOrderedQueryable<T>> OrderBy = null, string includeProperty = null);
        T GetFirstORDefault(Expression<Func<T, bool>> filter = null, string includeProperty = null);

        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity); 

    }
}
