using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebsiteBuilder.Core.Repositories
{
   public interface IGenericRepository<T> where T : class
    {
         Task<IList<T>>All(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Add(T entity);
        Task<bool> Delete(Guid id, T entity);
        Task<T> Update(T entity);
    }
}
