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
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Product Add(Product Entity)
        {
            _uow.ProductRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.ProductRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.ProductRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(Product Entity)
        {
            _uow.ProductRepository.Remove(Entity);
            _uow.SaveChangeAsync();
            
        }

        public Product Update(Product Entity)
        {
            _uow.ProductRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
