using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data.Aircraft
{
    public class PlaneTypesRepository : EFRepository<PlaneType>
    {
        public PlaneTypesRepository()
        {

        }

        public PlaneTypesRepository(AirportContext context)
            : base(context)
        {

        }
    }
}
