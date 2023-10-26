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
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public User Add(User Entity)
        {
            _uow.UserRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.UserRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.UserRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(User Entity)
        {
            _uow.UserRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public User Update(User Entity)
        {
            _uow.UserRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
