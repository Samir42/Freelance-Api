using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Freelancer.Domain.Abstractions {
    public interface IRepository<T> {
        Task<T> GetAsync(int id);
        void Add(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        void Delete(int id);
        void Edit(T entity);
        void Save();
    }
}
