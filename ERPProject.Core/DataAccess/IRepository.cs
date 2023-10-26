using ERPProject.Core.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Core.DataAccess
{
    public interface IRepository<T> where T :class,IEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties);
        EntityEntry<T> Add(T Entity);
        EntityEntry<T> Update(T Entity);
        void Remove(T Entity);
    }
}
