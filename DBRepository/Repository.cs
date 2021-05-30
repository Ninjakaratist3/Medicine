using Microsoft.EntityFrameworkCore;
using Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase<long>
    {
        private RepositoryContext _context;

        private DbSet<T> _dbSet;

        public Repository(RepositoryContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T GetById(long id)
        {
            return _dbSet.Where(t => t.Id == id).FirstOrDefault();
        }

        public IQueryable<T> Query()
        {
            return _dbSet;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
