using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class PlaneTypesRepository : MemRepository<PlaneType>
    {

        public PlaneTypesRepository(AirportContext context)
            : base(context)
        {

        }
    }
}
