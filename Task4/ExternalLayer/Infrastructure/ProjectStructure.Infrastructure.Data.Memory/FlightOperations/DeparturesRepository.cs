using System.Collections.Generic;
using ProjectStructure.Domain;
using System.Linq;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class DeparturesRepository : Repository<Departure>
    {
        public DeparturesRepository(AirportContext context)
            : base(context)
        {

        }

        public override bool Delete(long id)
        {
            var item = Context.Departures.FirstOrDefault(d => d.Id == id);
            return item != null ? Context.Departures.Remove(item) : false;
        }

        public override Departure Get(long id)
        {
            return Context.Departures.FirstOrDefault(d => d.Id == id);
        }

        public override IEnumerable<Departure> GetAll()
        {
            return Context.Departures ?? null;
        }

        public override Departure Insert(Departure entity)
        {
            if (Context.Departures.Contains(entity))
                return null;
            Context.Departures.Add(entity);
            return entity;
        }

        public override Departure Update(Departure entity)
        {
            if (Context.Departures.Contains(entity))
                return null;
            var newCollection = Context.Departures.ToList();
            newCollection[newCollection.IndexOf(entity)] = entity;
            Context.Departures = newCollection;
            return entity;
        }
    }
}
