using ProjectStructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class FlightsRepository : Repository<Flight>
    {
        public FlightsRepository(AirportContext context)
            : base(context)
        {

        }

        public override bool Delete(long id)
        {
            var item = Context.Flights.FirstOrDefault(d => d.Id == id);
            return item != null ? Context.Flights.Remove(item) : false;
        }

        public override Flight Get(long id)
        {
            return Context.Flights.FirstOrDefault(d => d.Id == id);
        }

        public override IEnumerable<Flight> GetAll()
        {
            return Context.Flights ?? null;
        }

        public override Flight Insert(Flight entity)
        {
            if (Context.Flights.Contains(entity))
                return null;
            Context.Flights.Add(entity);
            return entity;
        }

        public override Flight Update(Flight entity)
        {
            if (Context.Flights.Contains(entity))
                return null;
            var newCollection = Context.Flights.ToList();
            newCollection[newCollection.IndexOf(entity)] = entity;
            Context.Flights = newCollection;
            return entity;
        }
    }
}
