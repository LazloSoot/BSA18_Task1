using System;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Crewing
{
    public class CrewingUnitOfWork : ICrewingUnitOfWork
    {
       // private readonly DbContext dbContext;

        public IRepository<Crew> Crews { get; }

        public IRepository<Pilot> Pilots { get; }

        public IRepository<Stewardess> Stewardesses { get; }

        public CrewingUnitOfWork(IRepository<Crew> crewsRepository, IRepository<Pilot> pilotsRepository,
            IRepository<Stewardess> stewardessesRepository
            //DbContext context
            )
        {
            Crews = crewsRepository;
            Pilots = pilotsRepository;
            Stewardesses = stewardessesRepository;
            //dbContext = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IRepository<T> Set<T>() where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
