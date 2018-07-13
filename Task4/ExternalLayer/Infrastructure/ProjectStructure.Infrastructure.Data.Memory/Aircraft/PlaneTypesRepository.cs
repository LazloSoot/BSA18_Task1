using ProjectStructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class PlaneTypesRepository : Repository<PlaneType>
    {

        public PlaneTypesRepository(AirportContext context)
            : base(context)
        {

        }

        public override bool Delete(long id)
        {
            var item = Context.PlaneTypes.FirstOrDefault(d => d.Id == id);
            return item != null ? Context.PlaneTypes.Remove(item) : false;
        }

        public override PlaneType Get(long id)
        {
            return Context.PlaneTypes.FirstOrDefault(d => d.Id == id);
        }

        public override IEnumerable<PlaneType> GetAll()
        {
            return Context.PlaneTypes ?? null;
        }

        public override PlaneType Insert(PlaneType entity)
        {
            if (Context.PlaneTypes.Contains(entity))
                return null;
            Context.PlaneTypes.Add(entity);
            return entity;
        }

        public override PlaneType Update(PlaneType entity)
        {
            if (Context.PlaneTypes.Contains(entity))
                return null;
            var newCollection = Context.PlaneTypes.ToList();
            newCollection[newCollection.IndexOf(entity)] = entity;
            Context.PlaneTypes = newCollection;
            return entity;
        }
    }
}
