using System.Collections.Generic;

namespace FinanceBackEnd.Services.Interfaces  
{
    public interface IService<T> {

        void Create(T model);

        void Update(int id, T model);

        void Delete(T model);

        IList<T> Get();

        T GetBy(int id);
    }
}