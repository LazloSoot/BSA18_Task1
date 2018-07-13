using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data.FlightOperations
{
    public class DeparturesRepository : EFRepository<Departure>
    {
        public DeparturesRepository()
        {

        }

        public DeparturesRepository(AirportContext context)
            : base(context)
        {

        }
    }
}
