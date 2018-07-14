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

        public IEnumerable<Crew> GetAllCrewsInfo()
        {
            return uow.Crews.GetAll() ?? null;
        }

        public Crew AddCrew(Crew crew)
        {
            var item = uow.Crews.Insert(crew);
            if (item == null)
                return null;
            else
                uow.SaveChanges();
            return item;
        }

        public Crew CreateCrew(Pilot pilot, IEnumerable<Stewardess> stewardesses)
        {
            var item = uow.Crews.Insert(new Crew(pilot, stewardesses.ToList()));
            if (item == null)
                return null;
            else
                uow.SaveChanges();
            return item;
        }

        public Crew ReformCrew(Crew crew)
        {
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
