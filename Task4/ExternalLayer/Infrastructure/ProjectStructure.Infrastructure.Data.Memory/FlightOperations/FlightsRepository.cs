using System;
using System.Collections.Generic;
using System.Text;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class FlightsRepository : IRepository<Flight>
    {
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Flight Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Flight entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Flight entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Flight entity)
        {
            throw new NotImplementedException();
        }
    }
}
