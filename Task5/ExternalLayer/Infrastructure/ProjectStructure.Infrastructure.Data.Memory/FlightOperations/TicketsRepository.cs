using ProjectStructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class TicketsRepository : Repository<Ticket>
    {
        public TicketsRepository(AirportContext context)
            : base(context)
        {

        }

        public override bool Delete(long id)
        {
            var item = Context.Tickets.FirstOrDefault(d => d.Id == id);
            return item != null ? Context.Tickets.Remove(item) : false;
        }

        public override Ticket Get(long id)
        {
            return Context.Tickets.FirstOrDefault(d => d.Id == id);
        }

        public override IEnumerable<Ticket> GetAll()
        {
            return Context.Tickets ?? null;
        }

        public override Ticket Insert(Ticket entity)
        {
            if (Context.Tickets.Contains(entity))
                return null;
            Context.Tickets.Add(entity);
            return entity;
        }

        public override Ticket Update(Ticket entity)
        {
            if (Context.Tickets.Contains(entity))
                return null;
            var newCollection = Context.Tickets.ToList();
            newCollection[newCollection.IndexOf(entity)] = entity;
            Context.Tickets = newCollection;
            return entity;
        }
    }
}
