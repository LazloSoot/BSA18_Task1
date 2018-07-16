using ProjectStructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class CrewsRepository : Repository<Crew>
    {
        public CrewsRepository(AirportContext context)
            : base(context)
        {

        }

        public override bool Delete(long id)
        {
            var item = Context.Crews.FirstOrDefault(d => d.Id == id);
            return item != null ? Context.Crews.Remove(item) : false;
        }

        public override Crew Get(long id)
        {
            return Context.Crews.FirstOrDefault(d => d.Id == id) ?? null;
        }

        public override IEnumerable<Crew> GetAll()
        {
            return Context.Crews ?? null;
        }

        public override Crew Insert(Crew entity)
        {
            if (Context.Crews.Contains(entity))
                return null;
            Context.Crews.Add(entity);
            return entity;
        }

        public override Crew Update(Crew entity)
        {
            if (Context.Crews.Contains(entity))
                return null;
            var newCollection = Context.Crews.ToList();
            newCollection[newCollection.IndexOf(entity)] = entity;
            Context.Crews = newCollection;
            return entity;
        }
    }
}
