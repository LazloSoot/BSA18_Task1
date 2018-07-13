using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data.FlightOperations
{
    public class FlightsRepository : EFRepository<Flight>
    {
        public FlightsRepository()
        {

        }

        public FlightsRepository(AirportContext context)
            : base(context)
        {

        }
    }
}
