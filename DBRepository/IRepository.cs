using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository
{
    public interface IRepository<T> where T : class
    {
        T GetById(long id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void Update(T entity);
        IQueryable<T> Query();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
