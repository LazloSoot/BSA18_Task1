using ProjectStructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class StewardessesRepository : Repository<Stewardess>
    {
        public StewardessesRepository(AirportContext context)
            : base(context)
        {

        }

        public override bool Delete(long id)
        {
            var item = Context.Stewardesses.FirstOrDefault(d => d.Id == id);
            return item != null ? Context.Stewardesses.Remove(item) : false;
        }

        public override Stewardess Get(long id)
        {
            return Context.Stewardesses.FirstOrDefault(d => d.Id == id);
        }

        public override IEnumerable<Stewardess> GetAll()
        {
            return Context.Stewardesses ?? null;
        }

        public override Stewardess Insert(Stewardess entity)
        {
            if (Context.Stewardesses.Contains(entity))
                return null;
            Context.Stewardesses.Add(entity);
            return entity;
        }

        public override Stewardess Update(Stewardess entity)
        {
            if (Context.Stewardesses.Contains(entity))
                return null;
            var newCollection = Context.Stewardesses.ToList();
            newCollection[newCollection.IndexOf(entity)] = entity;
            Context.Stewardesses = newCollection;
            return entity;
        }
    }
}
