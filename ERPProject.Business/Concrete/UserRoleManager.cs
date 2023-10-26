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
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUnitOfWork _uow;

        public UserRoleManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserRole Add(UserRole Entity)
        {
            _uow.UserRoleRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync(Expression<Func<UserRole, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.UserRoleRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<UserRole> GetAsync(Expression<Func<UserRole, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.UserRoleRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(UserRole Entity)
        {
            _uow.UserRoleRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public UserRole Update(UserRole Entity)
        {
            _uow.UserRoleRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
