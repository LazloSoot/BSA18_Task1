using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data.FlightOperations
{
    public class TicketsRepository : EFRepository<Ticket>
    {
        public TicketsRepository()
        {

        }

        public TicketsRepository(AirportContext context)
            : base(context)
        {

        }
    }
}
