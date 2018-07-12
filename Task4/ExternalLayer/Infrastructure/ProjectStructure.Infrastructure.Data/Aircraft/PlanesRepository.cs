using System;
using System.Collections.Generic;
using System.Text;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Aircraft
{
    public class PlanesRepository : IRepository<Plane>
    {
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Plane Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plane> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Plane entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Plane entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Plane entity)
        {
            throw new NotImplementedException();
        }
    }
}
