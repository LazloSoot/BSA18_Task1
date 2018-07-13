using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Crewing
{
    public class CrewingUOW : IUnitOfWork
    {
        private readonly object dbContext;
        private readonly IRepository<Crew> crews;
        private readonly IRepository<Pilot> pilots;
        private readonly IRepository<Stewardess> stewardesses;


        public CrewingUOW(IRepository<Crew> crewsRepository, IRepository<Pilot> pilotsRepository,
            IRepository<Stewardess> stewardessesRepository)
        {
            crews = crewsRepository;
            pilots = pilotsRepository;
            stewardesses = stewardessesRepository;
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
