using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStructure.Domain.Interfaces
{
    public interface IDbRepository<T> : IRepository<T> where T : Entity
    {

        Task<T> GetAsync(long id, CancellationToken ct);

        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);

        Task<T> InsertAsync(T entity, CancellationToken ct);

        Task InsertRangeAsync(IEnumerable<T> entities, CancellationToken ct);

        IEnumerable<T> GetAllIncluding(bool isCached = false, params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, bool isCached = false);

        IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, bool isCached = false, params Expression<Func<T, object>>[] includeProperties);
    }
}
