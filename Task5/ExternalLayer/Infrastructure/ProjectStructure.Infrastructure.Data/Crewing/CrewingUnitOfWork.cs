using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Crewing
{
    public class CrewingUnitOfWork : IDbCrewingUnitOfWork
    {
        private readonly AirportContext dbContext;

        public IDbRepository<Crew> Crews { get; }

        public IDbRepository<Pilot> Pilots { get; }

        public IDbRepository<Stewardess> Stewardesses { get; }

        public CrewingUnitOfWork(EFRepository<Crew> crewsRepository, EFRepository<Pilot> pilotsRepository,
            EFRepository<Stewardess> stewardessesRepository,
            AirportContext context
            )
        {
            crewsRepository.DbContext = context;
            pilotsRepository.DbContext = context;
            stewardessesRepository.DbContext = context;
            dbContext = context;

            Crews = crewsRepository;
            Pilots = pilotsRepository;
            Stewardesses = stewardessesRepository;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
