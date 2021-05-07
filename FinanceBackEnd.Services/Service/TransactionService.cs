using System.Collections.Generic;
using FinanceBackEnd.Models.Model;
using FinanceBackEnd.Services.Interfaces;

namespace FinanceBackEnd.Services 
{
    public class TransactionService : IService<TransactionStock>
    {
        private IRepository _repository;
        
        public TransactionService(IRepository repository)
        {
            _repository = repository;
        }

        public void Create(TransactionStock model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TransactionStock model)
        {
            throw new System.NotImplementedException();
        }

        public IList<TransactionStock> Get()
        {
            throw new System.NotImplementedException();
        }

        public TransactionStock GetBy(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, TransactionStock model)
        {
            throw new System.NotImplementedException();
        }
    }
}