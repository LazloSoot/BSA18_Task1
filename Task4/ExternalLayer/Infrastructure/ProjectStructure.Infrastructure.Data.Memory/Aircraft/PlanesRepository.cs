using ProjectStructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class PlanesRepository : Repository<Plane>
    {

        public PlanesRepository(AirportContext context)
            :base(context)
        {

        }

        public override bool Delete(long id)
        {
            var item = Context.Planes.FirstOrDefault(d => d.Id == id);
            return item != null ? Context.Planes.Remove(item) : false;
        }

        public override Plane Get(long id)
        {
            return Context.Planes.FirstOrDefault(d => d.Id == id);
        }

        public override IEnumerable<Plane> GetAll()
        {
            return Context.Planes ?? null;
        }

        public override Plane Insert(Plane entity)
        {
            if (Context.Planes.Contains(entity))
                return null;
            Context.Planes.Add(entity);
            return entity;
        }

        public override Plane Update(Plane entity)
        {
            if (Context.Planes.Contains(entity))
                return null;
            var newCollection = Context.Planes.ToList();
            newCollection[newCollection.IndexOf(entity)] = entity;
            Context.Planes = newCollection;
            return entity;
        }
    }
}
