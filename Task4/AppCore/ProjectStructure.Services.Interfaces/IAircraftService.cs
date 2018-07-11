using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Services.Interfaces
{
    public interface IAircraftService
    {
        //Plane GetPlane(long id);

        //PlaneType GetPlaneType(long id);

        //void AddPlane(Plane plane);

        //void AddPlaneType(PlaneType planeType);

        //void RemovePlane(long id);

        //void RemovePlaneType(long id);

        TechCondition GetPlaneTechCondition(long id);
        
        Plane CarryOutMaintenance(long id);
    }
}
