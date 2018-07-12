using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjectStructure.Services
{
    public class CrewingService : ICrewingService
    {
        #region Crews

        public Crew GetCrewInfo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Crew> GetAllCrewsInfo()
        {
            throw new NotImplementedException();
        }

        public Crew AddCrew(Crew crew)
        {
            throw new NotImplementedException();
        }

        public Crew CreateCrew(Pilot pilot, IEnumerable<Stewardess> stewardesses)
        {
            throw new NotImplementedException();
        }

        public Crew ReformCrew(Crew crew)
        {
            throw new NotImplementedException();
        }

        public bool TryDeleteCrew(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Pilots

        public Pilot GetPilotInfo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pilot> GetAllPilotsInfo()
        {
            throw new NotImplementedException();
        }

        public Pilot HirePilot(Pilot pilot)
        {
            throw new NotImplementedException();
        }

        public bool TryDismissPilot(int id)
        {
            throw new NotImplementedException();
        }

        public Pilot UpdatePilotInfo(Pilot pilot)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Stewardesses

        public Stewardess GetStewardessInfo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stewardess> GetAllStewardessesInfo()
        {
            throw new NotImplementedException();
        }

        public Stewardess HireStewardess(Stewardess stewardess)
        {
            throw new NotImplementedException();
        }

        public Stewardess UpdateStewardessInfo(Stewardess stewardess)
        {
            throw new NotImplementedException();
        }

        public bool TryDismissStewardess(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
