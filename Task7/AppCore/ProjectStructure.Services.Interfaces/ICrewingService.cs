using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProjectStructure.Domain;

namespace ProjectStructure.Services.Interfaces
{
    /// <summary>
    /// Сервис по набору и работой с персоналом.
    /// </summary>
    public interface ICrewingService
    {
        #region Crews

        Task LoadOutSourceCrewsAsync(string uri, int count = -1, CancellationToken ct = default(CancellationToken));

        Crew CreateCrew(long pilotId, IEnumerable<long> stewardessesIds);

        Task<Crew> CreateCrewAsync(long pilotId, IEnumerable<long> stewardessesIds, CancellationToken ct = default(CancellationToken));

        IEnumerable<Crew> GetAllCrewsInfo();

        Task<IEnumerable<Crew>> GetAllCrewsInfoAsync(CancellationToken ct = default(CancellationToken));

        Crew GetCrewInfo(long id);

        Task<Crew> GetCrewInfoAsync(long id, CancellationToken ct = default(CancellationToken));

        Crew GetIncludedCrewInfo(long id, bool isCatched = false);

      //  Crew AddCrew(Crew crew);

        Crew ReformCrew(long crewId, long pilotId, IEnumerable<long> stewardessesIds);

        Task<Crew> ReformCrewAsync(long crewId, long pilotId, IEnumerable<long> stewardessesIds, CancellationToken ct = default(CancellationToken));

        bool TryDeleteCrew(long id);

        Task<bool> TryDeleteCrewAsync(long id, CancellationToken ct = default(CancellationToken));

        #endregion

        #region Pilots

        IEnumerable<Pilot> GetAllPilotsInfo();

        Task<IEnumerable<Pilot>> GetAllPilotsInfoAsync(CancellationToken ct = default(CancellationToken));

        Pilot GetPilotInfo(long id);

        Task<Pilot> GetPilotInfoAsync(long id, CancellationToken ct = default(CancellationToken));

        Pilot HirePilot(Pilot pilot);

        Task<Pilot> HirePilotAsync(Pilot pilot, CancellationToken ct = default(CancellationToken));

        Pilot UpdatePilotInfo(long id, Pilot pilot);

        Task<Pilot> UpdatePilotInfoAsync(long id, Pilot pilot, CancellationToken ct = default(CancellationToken));

        bool TryDismissPilot(long id);

        Task<bool> TryDismissPilotAsync(long id, CancellationToken ct = default(CancellationToken));

        #endregion

        #region Stewardresses

        IEnumerable<Stewardess> GetAllStewardessesInfo();

        Task<IEnumerable<Stewardess>> GetAllStewardessesInfoAsync(CancellationToken ct = default(CancellationToken));

        Stewardess GetStewardessInfo(long id);

        Task<Stewardess> GetStewardessInfoAsync(long id, CancellationToken ct = default(CancellationToken));

        Stewardess HireStewardess(Stewardess stewardess);

        Task<Stewardess> HireStewardessAsync(Stewardess stewardess, CancellationToken ct = default(CancellationToken));

        Stewardess UpdateStewardessInfo(long id, Stewardess stewardess);

        Task<Stewardess> UpdateStewardessInfoAsync(long id, Stewardess stewardess, CancellationToken ct = default(CancellationToken));

        bool TryDismissStewardess(long id);

        Task<bool> TryDismissStewardessAsync(long id, CancellationToken ct = default(CancellationToken));

        #endregion
    }
}
