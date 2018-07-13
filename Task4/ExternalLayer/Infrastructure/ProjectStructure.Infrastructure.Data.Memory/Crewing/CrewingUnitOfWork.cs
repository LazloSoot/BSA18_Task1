using System;
using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class CrewingUnitOfWork : ICrewingUnitOfWork
    {
        private readonly AirportContext dbContext;

        public IRepository<Crew> Crews { get; }

        public IRepository<Pilot> Pilots { get; }

        public IRepository<Stewardess> Stewardesses { get; }

        public CrewingUnitOfWork(IRepository<Crew> crewsRepository, IRepository<Pilot> pilotsRepository,
            IRepository<Stewardess> stewardessesRepository,
            AirportContext context
            )
        {
            Crews = crewsRepository;
            Pilots = pilotsRepository;
            Stewardesses = stewardessesRepository;
            dbContext = context;
        }

        public void Dispose()
        {
        }

        public int SaveChanges()
        {
            return -1;
        }

        public Task<int> SaveChangesAsync()
        {
            return null;
        }
    }
}
