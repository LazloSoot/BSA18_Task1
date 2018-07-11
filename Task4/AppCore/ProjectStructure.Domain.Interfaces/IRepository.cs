using System;
using System.Collections.Generic;
using System.Text;
using ProjectStructure.Domain;

namespace ProjectStructure.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();

        T Get(long id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(long id);

        void Remove(T entity);
    }
}
