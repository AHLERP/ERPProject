﻿using ERPProject.Business.Abstract;
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
    public class StockManager : IStockService
    {
        private readonly IUnitOfWork _uow;

        public StockManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Stock Add(Stock Entity)
        {
            _uow.StockRepository.Add(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Stock>> GetAllAsync(Expression<Func<Stock, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.StockRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Stock> GetAsync(Expression<Func<Stock, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.StockRepository.GetAsync(Filter, IncludeProperties);
        }

        public void Remove(Stock Entity)
        {
            _uow.StockRepository.Remove(Entity);
            _uow.SaveChangeAsync();
        }

        public Stock Update(Stock Entity)
        {
            _uow.StockRepository.Update(Entity);
            _uow.SaveChangeAsync();
            return Entity;
        }
    }
}
