using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected AirportContext Context { get;}

        public Repository(AirportContext context)
        {
            Context = context;
        }

        public abstract IEnumerable<T> GetAll();
        public abstract T Get(long id);
        public abstract T Insert(T entity);
        public abstract T Update(T entity);
        public abstract bool Delete(long id);
    }
}
