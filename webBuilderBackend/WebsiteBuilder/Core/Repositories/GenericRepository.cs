using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebsiteBuilder.Data;

namespace WebsiteBuilder.Core.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        protected MyDBContext context;
        protected DbSet<T> dbSet;

        public GenericRepository(
            MyDBContext _context

            )
        {
              context = _context;
            this.dbSet = context.Set<T>();

        }

        public async  Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async virtual Task<T> Add(T entity)
        {
             dbSet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id,T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<T> Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return  entity;
        }

        public async Task<IList<T>>All(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
