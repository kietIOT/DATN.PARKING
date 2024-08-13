using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TCIS.TTOS.EDI.DAL
{
    public interface IGenericRepository<T>
            where T : class
    {
        T FindOne(Expression<Func<T, bool>> filter = null,
                  string includeProperties = "");

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "");

        IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> filter = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                     string includeProperties = "");

        IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                              string includeProperties = "");

        IQueryable<T> GetAllAsQueryable(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeProperties = "");

        T GetById(object id);

        T Insert(T entity);

        T Update(T entity);

        T Delete(T entity);

        void DeleteMulti(IEnumerable<T> entities);
    }
}
