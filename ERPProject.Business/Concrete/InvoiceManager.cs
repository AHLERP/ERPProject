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
    public class InvoiceManager : IInvoiceService
    {
        private readonly IUnitOfWork _uow;

        public InvoiceManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Invoice Add(Invoice Entity)
        {
            _uow.InvoiceRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync(Expression<Func<Invoice, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.InvoiceRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Invoice> GetAsync(Expression<Func<Invoice, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.InvoiceRepository.GetAsync(Filter,IncludeProperties);
        }

        public void Remove(Invoice Entity)
        {
            _uow.InvoiceRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public Invoice Update(Invoice Entity)
        {
            _uow.InvoiceRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
