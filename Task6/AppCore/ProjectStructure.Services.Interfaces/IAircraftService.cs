using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using System.Collections.Generic;

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

     //   Plane RepearPlane(Plane plane);

        IEnumerable<Plane> GetAllPlanesInfo();

        Plane GetPlaneInfo(long id);

        Plane GetPlaneInfoIncluded(long id);

        Plane AddPlane(Plane plane);

        Plane ModifyPlaneInfo(long id, Plane plane);

        bool TryDeletePlane(long id);

        #endregion

        #region PlaneTypes

        IEnumerable<PlaneType> GetAllPlaneTypesInfo();

        PlaneType GetPlaneTypeInfo(long id);

        PlaneType AddPlaneType(PlaneType type);

        PlaneType ModifyPlaneType(long id, PlaneType type);

        bool TryDeletePlaneType(long id);

        #endregion
    }
}
