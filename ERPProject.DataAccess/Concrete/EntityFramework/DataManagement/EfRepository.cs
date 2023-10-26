using ERPProject.Core.DataAccess;
using ERPProject.Core.Entity;
using ERPProject.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.DataAccess.Concrete.EntityFramework.DataManagement
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EfRepository( DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            
        }

        public  EntityEntry<T> Add(T Entity)
        {
            return  _dbContext.Set<T>().Add(Entity);
            
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties)
        {
            IQueryable<T> query;
            query = _dbSet;
            if (Filter != null)
            {
                query = query.Where(Filter);/* select * from product where id>5 */
            }

            if (IncludeProperties.Length > 0)
            {
                foreach (var item in IncludeProperties)
                {
                    query = query.Include(item);
                }
            }

            return await Task.Run(() => query);

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(Filter);
            if (IncludeProperties.Length > 0)
            {
                foreach (var item in IncludeProperties)
                {
                    query = query.Include(item);
                }
            }

            return await query.SingleOrDefaultAsync();
        }

        public void Remove(T Entity)
        {
            _dbSet.Remove(Entity);
        }

        public EntityEntry<T> Update(T Entity)
        {
            return _dbSet.Update(Entity);
        }
    }
}
