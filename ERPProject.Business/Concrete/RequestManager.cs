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
    public class RequestManager : IRequestService
    {
        private readonly IUnitOfWork _uow;

        public RequestManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Request Add(Request Entity)
        {
            _uow.RequestRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public Task<IEnumerable<Request>> GetAllAsync(Expression<Func<Request, bool>> Filter = null, params string[] IncludeProperties)
        {
            return _uow.RequestRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public Task<Request> GetAsync(Expression<Func<Request, bool>> Filter, params string[] IncludeProperties)
        {
            return _uow.RequestRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(Request Entity)
        {
            _uow.RequestRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public Request Update(Request Entity)
        {
            _uow.RequestRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
