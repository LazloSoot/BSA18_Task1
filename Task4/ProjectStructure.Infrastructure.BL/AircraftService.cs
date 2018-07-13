using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly IUnitOfWork uow;
        public AircraftService()
        {

        }
        #region Planes Methods

        public TechCondition GetPlaneTechCondition(long id)
        {
            throw new NotImplementedException();
        }

        public Plane CarryOutMaintenance(long id)
        {
            throw new NotImplementedException();
        }

        public Plane AddPlane(Plane plane)
        {
            throw new NotImplementedException();
        }

        public Plane GetPlaneInfo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plane> GetAllPlanesInfo()
        {
            throw new NotImplementedException();
        }

        public Plane ModifyPlaneInfo(Plane plane)
        {
            throw new NotImplementedException();
        }

        public bool TryDeletePlane(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PlaneTypes Methods

        public PlaneType AddPlaneType(PlaneType type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaneType> GetAllPlaneTypesInfo()
        {
            throw new NotImplementedException();
        }

        public PlaneType GetPlaneTypeInfo(int id)
        {
            throw new NotImplementedException();
        }

        public PlaneType ModifyPlaneType(int id, PlaneType type)
        {
            throw new NotImplementedException();
        }

        public bool TryDeletePlaneType(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
