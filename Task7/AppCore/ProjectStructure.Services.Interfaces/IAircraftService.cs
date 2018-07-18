using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStructure.Services.Interfaces
{
    /// <summary>
    /// Сервис тех. обслуживания самолетов.
    /// </summary>
    public interface IAircraftService
    {
        #region Planes
        
        CheckNeeded GetPlaneTechCondition(Plane plane);

        CheckNeeded GetPlaneTechCondition(long id);

        Plane CarryOutMaintenance(Plane plane, CheckNeeded cheks);

        Task<Plane> CarryOutMaintenanceAsync(Plane plane, CheckNeeded cheks, CancellationToken ct = default(CancellationToken));

        //   Plane RepearPlane(Plane plane);

        IEnumerable<Plane> GetAllPlanesInfo();

        Task<IEnumerable<Plane>> GetAllPlanesInfoAsync(CancellationToken ct = default(CancellationToken));

        Plane GetPlaneInfo(long id);

        Task<Plane> GetPlaneInfoAsync(long id, CancellationToken ct = default(CancellationToken));

        Plane GetPlaneInfoIncluded(long id);

        Plane AddPlane(Plane plane);

        Task<Plane> AddPlaneAsync(Plane plane, CancellationToken ct = default(CancellationToken));

        Plane ModifyPlaneInfo(long id, Plane plane);

        Task<Plane> ModifyPlaneInfoAsync(long id, Plane plane, CancellationToken ct = default(CancellationToken));

        bool TryDeletePlane(long id);

        Task<bool> TryDeletePlaneAsync(long id);

        #endregion

        #region PlaneTypes

        IEnumerable<PlaneType> GetAllPlaneTypesInfo();

        Task<IEnumerable<PlaneType>> GetAllPlaneTypesInfoAsync(CancellationToken ct = default(CancellationToken));

        PlaneType GetPlaneTypeInfo(long id);

        Task<PlaneType> GetPlaneTypeInfoAsync(long id, CancellationToken ct = default(CancellationToken));

        PlaneType AddPlaneType(PlaneType type);

        Task<PlaneType> AddPlaneTypeAsync(PlaneType type, CancellationToken ct = default(CancellationToken));

        PlaneType ModifyPlaneType(long id, PlaneType type);

        Task<PlaneType> ModifyPlaneTypeAsync(long id, PlaneType type, CancellationToken ct = default(CancellationToken));

        bool TryDeletePlaneType(long id);

        Task<bool> TryDeletePlaneTypeAsync(long id, CancellationToken ct = default(CancellationToken));

        #endregion
    }
}
