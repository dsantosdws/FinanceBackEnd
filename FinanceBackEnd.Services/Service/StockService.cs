using System.Collections.Generic;
using FinanceBackEnd.Models.Model;
using FinanceBackEnd.Services.Interfaces;

namespace FinanceBackEnd.Services.Service {
    public class StockService : IService<Stock>
    {
        private IRepository _repository;

        public StockService(IRepository repository) {
            _repository = repository;
        }

        public void Create(Stock model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Stock model)
        {
            throw new System.NotImplementedException();
        }

        public IList<Stock> Get()
        {
            throw new System.NotImplementedException();
        }

        public Stock GetBy(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Stock model)
        {
            throw new System.NotImplementedException();
        }
    }
}