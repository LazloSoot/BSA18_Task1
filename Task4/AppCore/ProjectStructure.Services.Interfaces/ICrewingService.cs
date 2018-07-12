using System.Collections.Generic;
using ProjectStructure.Domain;

namespace ProjectStructure.Services.Interfaces
{
    /// <summary>
    /// Сервис по набору и работой с персоналом.
    /// </summary>
    public interface ICrewingService
    {
        #region Crews

        Crew CreateCrew(Pilot pilot, IEnumerable<Stewardess> stewardesses);

        IEnumerable<Crew> GetAllCrewsInfo();

        Crew GetCrewInfo(int id);

        Crew AddCrew(Crew crew);

        Crew ReformCrew(Crew crew);

        bool TryDeleteCrew(int id);

        #endregion

        #region Pilots

        IEnumerable<Pilot> GetAllPilotsInfo();

        Pilot GetPilotInfo(int id);

        Pilot HirePilot(Pilot pilot);

        Pilot UpdatePilotInfo(Pilot pilot);

        bool TryDismissPilot(int id);

        #endregion

        #region Stewardresses

        IEnumerable<Stewardess> GetAllStewardessesInfo();

        Stewardess GetStewardessInfo(int id);

        Stewardess HireStewardess(Stewardess stewardess);

        Stewardess UpdateStewardessInfo(Stewardess stewardess);

        bool TryDismissStewardess(int id);


        #endregion
    }
}
