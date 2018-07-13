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

        Crew GetCrewInfo(long id);

        Crew AddCrew(Crew crew);

        Crew ReformCrew(Crew crew);

        bool TryDeleteCrew(long id);

        #endregion

        #region Pilots

        IEnumerable<Pilot> GetAllPilotsInfo();

        Pilot GetPilotInfo(long id);

        Pilot HirePilot(Pilot pilot);

        Pilot UpdatePilotInfo(Pilot pilot);

        bool TryDismissPilot(long id);

        #endregion

        #region Stewardresses

        IEnumerable<Stewardess> GetAllStewardessesInfo();

        Stewardess GetStewardessInfo(long id);

        Stewardess HireStewardess(Stewardess stewardess);

        Stewardess UpdateStewardessInfo(Stewardess stewardess);

        bool TryDismissStewardess(long id);


        #endregion
    }
}
