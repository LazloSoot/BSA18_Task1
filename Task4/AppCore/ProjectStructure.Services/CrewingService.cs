using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;
using ProjectStructure.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjectStructure.Services
{
    public class CrewingService : ICrewingService
    {
#warning заменить на ICrewRepository?
        private readonly IRepository<Crew> repository;

        public CrewingService(IRepository<Crew> repository)
        {
            this.repository = repository;
        }

        public void CreateCrew(Pilot pilot, IEnumerable<Stewardess> stewardesses)
        {
            repository.Insert(new Crew()
            {
                Pilot = pilot,
                Stewardesses = stewardesses
            });
        }
    }
}
