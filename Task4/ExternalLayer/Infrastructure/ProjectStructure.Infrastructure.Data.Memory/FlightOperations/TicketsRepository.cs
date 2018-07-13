using System;
using System.Collections.Generic;
using System.Text;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class TicketsRepository : IRepository<Ticket>
    {
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Ticket Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
