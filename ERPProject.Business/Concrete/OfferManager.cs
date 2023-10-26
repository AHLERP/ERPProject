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
    public class OfferManager : IOfferService
    {
        private readonly IUnitOfWork _uow;

        public OfferManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Offer Add(Offer Entity)
        {
            _uow.OfferRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Offer>> GetAllAsync(Expression<Func<Offer, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.OfferRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Offer> GetAsync(Expression<Func<Offer, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.OfferRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(Offer Entity)
        {
            _uow.OfferRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public Offer Update(Offer Entity)
        {
            _uow.OfferRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
