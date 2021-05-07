using System;
using System.Collections.Generic;
using System.Linq;
using FinanceBackEnd.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace FinanceBackEnd.Infrastructure.Repositories 
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbSet<T> _dbSet;
        private DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public DbContext GetContext()
        {
            return _context;
        }

        public virtual T Get(int id)
        {
            return
               this.Get(true)
               .Where(p => p.Id == id)
               .Single();
        }

        public virtual IEnumerable<T> Get(List<int> ids)
        {
            return
              this.Get(true)
              .Where(p => ids.Contains(p.Id))
              .ToList();
        }

        public T Insert(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);

            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = this.Get(id);
            this.Delete(entity);
        }

        public virtual void Delete(List<int> ids)
        {
            var entities = this.Get(ids);

            foreach (var item in entities)
            {
                this.Delete(item);
            }
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Get(bool track = true)
        {
            if (!track)
            {
                return _dbSet.AsNoTracking();
            }

            return _dbSet;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}