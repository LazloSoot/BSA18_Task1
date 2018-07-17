using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;
using ProjectStructure.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace ProjectStructure.Infrastructure.BL
{
    public class CrewingService : ICrewingService
    {
        private readonly IDbCrewingUnitOfWork uow;
        public CrewingService(IDbCrewingUnitOfWork crewingUnitOfWork)
        {
            uow = crewingUnitOfWork;
        }
        #region Crews

        public Crew GetCrewInfo(long id)
        {
            return uow.Crews.Get(id) ?? null;
        }

        public Crew GetIncludedCrewInfo(long id, bool isCatched = false)
        {
            return uow.Crews.FindByInclude(e => e.Id == id, isCatched, 
                e => e.Pilot, e=> e.Stewardesses)
                .FirstOrDefault()
                ?? null;
        }

        public IEnumerable<Crew> GetAllCrewsInfo()
        {
            return uow.Crews.GetAll() ?? null;
        }

        public Crew CreateCrew(long pilotId, IEnumerable<long> stewardessesIds)
        {
            var pilot = uow.Pilots.Get(pilotId);
            if (pilot == null)
                return null;
            var stewardesses = uow.Stewardesses.FindBy(s => stewardessesIds.Contains(s.Id));
            if (stewardesses == null || stewardesses.Count() < 2)
                return null;

            var item = uow.Crews.Update(new Crew(pilot, stewardesses.ToList()));
            if (item == null)
                return null;
            else
                uow.SaveChanges();
            return item;
        }

        public Crew ReformCrew(long crewId, long pilotId, IEnumerable<long> stewardessesIds)
        {
            var crew = uow.Crews.Get(crewId);
            if (crew == null)
                return null;

            if(crew.Pilot.Id != pilotId)
            {
                var pilot = uow.Pilots.Get(pilotId);
                if (pilot == null)
                    return null;
                crew.Pilot = pilot;
            }
            
            var stewardesses = uow.Stewardesses.FindBy(s => stewardessesIds.Contains(s.Id));
            if (stewardesses == null || stewardesses.Count() < 2)
                return null;
            crew.Stewardesses = stewardesses.ToList();

            var item = uow.Crews.Update(crew);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public bool TryDeleteCrew(long id)
        {
            if (uow.Crews.Delete(id))
            {
                uow.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Pilots

        public Pilot GetPilotInfo(long id)
        {
            return uow.Pilots.Get(id) ?? null;
        }

        public IEnumerable<Pilot> GetAllPilotsInfo()
        {
            return uow.Pilots.GetAll() ?? null;
        }

        public Pilot HirePilot(Pilot pilot)
        {
            var item = uow.Pilots.Insert(pilot);
            if (item == null)
                return null;
            else
                uow.SaveChanges();
            return item;
        }

        public bool TryDismissPilot(long id)
        {
            if (uow.Pilots.Delete(id))
            {
                uow.SaveChanges();
                return true;
            }
            return false;
        }

        public Pilot UpdatePilotInfo(Pilot pilot)
        {
            var item = uow.Pilots.Update(pilot);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        #endregion

        #region Stewardesses

        public Stewardess GetStewardessInfo(long id)
        {
            return uow.Stewardesses.Get(id) ?? null;
        }

        public IEnumerable<Stewardess> GetAllStewardessesInfo()
        {
            return uow.Stewardesses.GetAll() ?? null;
        }

        public Stewardess HireStewardess(Stewardess stewardess)
        {
            var item = uow.Stewardesses.Insert(stewardess);
            if (item == null)
                return null;
            else
                uow.SaveChanges();
            return item;
        }

        public Stewardess UpdateStewardessInfo(Stewardess stewardess)
        {
            var item = uow.Stewardesses.Update(stewardess);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public bool TryDismissStewardess(long id)
        {
            if (uow.Stewardesses.Delete(id))
            {
                uow.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion
    }
}
