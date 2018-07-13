using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data.Crewing
{
    public class CrewsRepository : EFRepository<Crew>
    {
        public CrewsRepository()
        {

        }

        public CrewsRepository(AirportContext context)
            :base(context)
        {

        }
    }
}
