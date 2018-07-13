using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class PlanesRepository : MemRepository<Plane>
    {

        public PlanesRepository(AirportContext context)
            :base(context)
        {

        }
    }
}
