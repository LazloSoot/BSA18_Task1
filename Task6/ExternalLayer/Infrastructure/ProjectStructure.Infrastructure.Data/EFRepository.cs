using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data
{
    public abstract class EFRepository<T> : IDbRepository<T> where T: Entity
    {
        internal DbContext DbContext { get; set; }

        public EFRepository()
        {

        }
        public EFRepository(DbContext context)
        {
            DbContext = context;
        }

        public virtual bool Delete(long id)
        {
            var item = DbContext.Set<T>().Find(id);
            if (item == null)
                return false;
            DbContext.Set<T>().Remove(item);
            return true;
        }

        public virtual T Get(long id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().AsTracking();
        }

        public virtual T Insert(T entity)
        {
            if (DbContext.Set<T>().Find(entity.Id) != null)
                return null;
            DbContext.Set<T>().Add(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            //if (DbContext.Set<T>().Find(entity.Id) == null)
            //    return null;
            DbContext.Set<T>().Update(entity);
            return entity;
        }

        public IEnumerable<T> GetAllIncluding(bool isCached = false, params Expression<Func<T, object>>[] includeProperties)
        {
            return AllInclude(isCached, includeProperties)
                .ToList();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, bool isCached = false)
        {
            if (isCached)
            {
                return DbContext.Set<T>()
                .Where(predicate)
                .ToList();
            }
            else
            {
                return DbContext.Set<T>()
                 .AsNoTracking()
                 .Where(predicate)
                 .ToList();
            }
        }

        public IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, bool isCached = false, params Expression<Func<T, object>>[] includeProperties)
        {
            return AllInclude(isCached, includeProperties)
                .Where(predicate)
                .ToList();
        }

        protected IQueryable<T> AllInclude(bool isCached = false, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = isCached ? DbContext.Set<T>().AsTracking() : DbContext.Set<T>().AsNoTracking();
            return includeProperties
                .Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
