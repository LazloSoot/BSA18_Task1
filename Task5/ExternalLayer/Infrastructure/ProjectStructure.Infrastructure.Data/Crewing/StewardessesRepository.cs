using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data.Crewing
{
    public class StewardessesRepository : EFRepository<Stewardess>
    {
        public StewardessesRepository()
        {

        }

        public StewardessesRepository(AirportContext context)
            : base(context)
        {

        }
    }
}
