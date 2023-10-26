using ERPProject.Business.Abstract;
using ERPProject.DataAccess.Abstract.DataManagement;
using ERPProject.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IUnitOfWork _uow;

        public DepartmentManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Department Add(Department Entity)
        {
            _uow.DepartmentRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Department>> GetAllAsync(Expression<Func<Department, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.DepartmentRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Department> GetAsync(Expression<Func<Department, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.DepartmentRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(Department Entity)
        {
            _uow.DepartmentRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public Department Update(Department Entity)
        {
            _uow.DepartmentRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
