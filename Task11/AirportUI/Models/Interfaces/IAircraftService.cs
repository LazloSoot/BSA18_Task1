using AirportUI.Models.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AirportUI.Models.Interfaces
{
    public interface IAircraftService
    {
        Plane AddPlane(Plane plane);
        Task<Plane> AddPlaneAsync(Plane plane, CancellationToken ct);
        PlaneType AddPlaneType(PlaneType type);
        Task<PlaneType> AddPlaneTypeAsync(PlaneType type, CancellationToken ct);
        IEnumerable<Plane> GetAllPlanesInfo();
        Task<IEnumerable<Plane>> GetAllPlanesInfoAsync(CancellationToken ct);
        IEnumerable<PlaneType> GetAllPlaneTypesInfo();
        Task<IEnumerable<PlaneType>> GetAllPlaneTypesInfoAsync(CancellationToken ct);
        Plane GetPlaneInfo(long id);
        Task<Plane> GetPlaneInfoAsync(long id, CancellationToken ct);
        Plane GetPlaneInfoIncluded(long id);
        PlaneType GetPlaneTypeInfo(long id);
        Task<PlaneType> GetPlaneTypeInfoAsync(long id, CancellationToken ct);
        Plane ModifyPlaneInfo(long id, Plane plane);
        Task<Plane> ModifyPlaneInfoAsync(long id, Plane plane, CancellationToken ct);
        PlaneType ModifyPlaneType(long id, PlaneType type);
        Task<PlaneType> ModifyPlaneTypeAsync(long id, PlaneType type, CancellationToken ct);
        bool TryDeletePlane(long id);
        Task<bool> TryDeletePlaneAsync(long id, CancellationToken ct);
        bool TryDeletePlaneType(long id);
        Task<bool> TryDeletePlaneTypeAsync(long id, CancellationToken ct);
    }
}
