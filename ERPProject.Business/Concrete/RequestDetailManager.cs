using Azure.Core;
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
    public class RequestDetailManager : IRequestDetailService
    {
        private readonly IUnitOfWork _uow;

        public RequestDetailManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<RequestDetail> AddAsync(RequestDetail Entity)
        {
            await _uow.RequestDetailRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<RequestDetail>> GetAllAsync(Expression<Func<RequestDetail, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.RequestDetailRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<RequestDetail> GetAsync(Expression<Func<RequestDetail, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.RequestDetailRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(RequestDetail Entity)
        {
            await _uow.RequestDetailRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(RequestDetail Entity)
        {
            await _uow.RequestDetailRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
