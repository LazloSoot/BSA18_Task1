using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data
{
    public abstract class EFRepository<T> : IRepository<T> where T: Entity
    {
        internal DbContext context;
        public EFRepository(DbContext context)
        {
            this.context = context;
        }

        public virtual bool Delete(long id)
        {
            var item = context.Set<T>().Find(id);
            if (item == null)
                return false;
            context.Set<T>().Remove(item);
            return true;
        }

        public virtual T Get(long id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsTracking();
        }

        public virtual T Insert(T entity)
        {
            if (context.Set<T>().Find(entity.Id) != null)
                return null;
            context.Set<T>().Add(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            if (context.Set<T>().Find(entity.Id) == null)
                return null;
            context.Set<T>().Update(entity);
            return entity;
        }
    }
}
