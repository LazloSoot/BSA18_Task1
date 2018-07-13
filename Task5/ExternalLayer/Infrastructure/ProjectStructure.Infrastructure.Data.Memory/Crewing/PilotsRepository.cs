using ProjectStructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class PilotsRepository : Repository<Pilot>
    {
        public PilotsRepository(AirportContext context)
            : base(context)
        {

        }
        public override bool Delete(long id)
        {
            var item = Context.Pilots.FirstOrDefault(d => d.Id == id);
            return item != null ? Context.Pilots.Remove(item) : false;
        }

        public override Pilot Get(long id)
        {
            return Context.Pilots.FirstOrDefault(d => d.Id == id);
        }

        public override IEnumerable<Pilot> GetAll()
        {
            return Context.Pilots ?? null;
        }

        public override Pilot Insert(Pilot entity)
        {
            if (Context.Pilots.Contains(entity))
                return null;
            Context.Pilots.Add(entity);
            return entity;
        }

        public override Pilot Update(Pilot entity)
        {
            if (Context.Pilots.Contains(entity))
                return null;
            var newCollection = Context.Pilots.ToList();
            newCollection[newCollection.IndexOf(entity)] = entity;
            Context.Pilots = newCollection;
            return entity;
        }
    }
}
