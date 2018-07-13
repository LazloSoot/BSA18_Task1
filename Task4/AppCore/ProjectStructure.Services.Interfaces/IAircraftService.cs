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

        TechCondition GetPlaneTechCondition(long id);

        Plane CarryOutMaintenance(long id);

        IEnumerable<Plane> GetAllPlanesInfo();

        Plane GetPlaneInfo(long id);

        Plane AddPlane(Plane plane);

        Plane ModifyPlaneInfo(Plane plane);

        bool TryDeletePlane(int id);

        #endregion

        #region PlaneTypes

        IEnumerable<PlaneType> GetAllPlaneTypesInfo();

        PlaneType GetPlaneTypeInfo(int id);

        PlaneType AddPlaneType(PlaneType type);

        PlaneType ModifyPlaneType(PlaneType type);

        bool TryDeletePlaneType(int id);

        #endregion
    }
}
