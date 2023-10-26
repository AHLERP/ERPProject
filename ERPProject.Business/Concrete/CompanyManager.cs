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
    public class CompanyManager : ICompanyService
    {
        private readonly IUnitOfWork _uow;

        public CompanyManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Company Add(Company Entity)
        {
            _uow.CompanyRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public Task<IEnumerable<Company>> GetAllAsync(Expression<Func<Company, bool>> Filter = null, params string[] IncludeProperties)
        {
            return _uow.CompanyRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public Task<Company> GetAsync(Expression<Func<Company, bool>> Filter, params string[] IncludeProperties)
        {
            return _uow.CompanyRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(Company Entity)
        {
            _uow.CompanyRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public Company Update(Company Entity)
        {
            _uow.CompanyRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
