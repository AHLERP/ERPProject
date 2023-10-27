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
    public class RoleManager : IRoleService
    {
        private readonly IUnitOfWork _uow;

        public RoleManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Role Add(Role Entity)
        {
            _uow.RoleRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Role>> GetAllAsync(Expression<Func<Role, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.RoleRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Role> GetAsync(Expression<Func<Role, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.RoleRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(Role Entity)
        {
            _uow.RoleRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public Role Update(Role Entity)
        {
            _uow.RoleRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
