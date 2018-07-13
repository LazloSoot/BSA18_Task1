using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data.Aircraft
{
    public class PlanesRepository : EFRepository<Plane>
    {

        public PlanesRepository(AirportContext context)
            :base(context)
        {

        }
    }
}
