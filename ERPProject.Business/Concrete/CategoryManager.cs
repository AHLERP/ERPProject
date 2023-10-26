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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Category Add(Category Entity)
        {
            _uow.CategoryRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.CategoryRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.CategoryRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(Category Entity)
        {
            _uow.CategoryRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public Category Update(Category Entity)
        {
            _uow.CategoryRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
