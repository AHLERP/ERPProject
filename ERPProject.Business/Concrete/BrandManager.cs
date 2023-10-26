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
    public class BrandManager : IBrandService
    {
        private readonly IUnitOfWork _uow;

        public BrandManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Brand Add(Brand Entity)
        {
            _uow.BrandRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync(Expression<Func<Brand, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.BrandRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Brand> GetAsync(Expression<Func<Brand, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.BrandRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(Brand Entity)
        {
            _uow.BrandRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public Brand Update(Brand Entity)
        {
            _uow.BrandRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
