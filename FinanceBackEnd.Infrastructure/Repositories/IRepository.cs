using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FinanceBackEnd.Infrastructure.Repositories 
{
    public interface IRepository<T> : IDisposable
    {
        T Get(int id);

        IEnumerable<T> Get(List<int> ids);

        T Insert(T entity);

        T Update(T entity);

        void Delete(int id);

        void Delete(List<int> ids);

        void Delete(T entity);

        #region Zona Cinzenta

        DbContext GetContext();

        IQueryable<T> Get(bool track = true);

        #endregion
    }
}