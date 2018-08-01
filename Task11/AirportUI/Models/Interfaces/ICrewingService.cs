using AirportUI.Models.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AirportUI.Models.Interfaces
{
    public interface ICrewingService
    {
        Task<Crew> CreateCrewAsync(long pilotId, IEnumerable<long> stewardessesIds, CancellationToken ct = default(CancellationToken));
        Task<IEnumerable<Crew>> GetAllCrewsInfoAsync(CancellationToken ct = default(CancellationToken));
        Task<IEnumerable<Pilot>> GetAllPilotsInfoAsync(CancellationToken ct = default(CancellationToken));
        Task<IEnumerable<Stewardess>> GetAllStewardessesInfoAsync(CancellationToken ct = default(CancellationToken));
        Task<Pilot> HirePilotAsync(Pilot pilot, CancellationToken ct = default(CancellationToken));
        Task<Stewardess> HireStewardessAsync(Stewardess stewardess, CancellationToken ct = default(CancellationToken));
        Task<Crew> ReformCrewAsync(long crewId, Crew crew, CancellationToken ct = default(CancellationToken));
        Task<bool> TryDeleteCrewAsync(long id, CancellationToken ct = default(CancellationToken));
        Task<bool> TryDismissPilotAsync(long id, CancellationToken ct = default(CancellationToken));
        Task<bool> TryDismissStewardessAsync(long id, CancellationToken ct = default(CancellationToken));
        Task<Pilot> UpdatePilotInfoAsync(long id, Pilot pilot, CancellationToken ct = default(CancellationToken));
        Task<Stewardess> UpdateStewardessInfoAsync(long id, Stewardess stewardess, CancellationToken ct = default(CancellationToken));
    }
}
