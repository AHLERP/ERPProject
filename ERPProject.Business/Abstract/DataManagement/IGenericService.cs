using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Business.Abstract.DataManagement
{
    public interface IGenericService<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties);

        T Add(T Entity);
        T Update(T Entity);
        void Remove(T Entity);
    }
}
