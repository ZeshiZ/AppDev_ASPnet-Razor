using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
        //it has general methods like ADD/DELETE/GETFIRST...
    }
}
