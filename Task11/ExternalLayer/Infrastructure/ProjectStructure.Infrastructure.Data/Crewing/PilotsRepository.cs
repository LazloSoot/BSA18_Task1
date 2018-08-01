using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data.Crewing
{
    public class PilotsRepository : EFRepository<Pilot>
    {
        public PilotsRepository()
        {

        }

        public PilotsRepository(AirportContext context)
            : base(context)
        {

        }
    }
}
