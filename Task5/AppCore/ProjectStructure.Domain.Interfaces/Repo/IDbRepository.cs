using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectStructure.Domain.Interfaces
{
    public interface IDbRepository<T> : IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAllIncluding(bool isCached = false, params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, bool isCached = false);

        IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, bool isCached = false, params Expression<Func<T, object>>[] includeProperties);
    }
}
