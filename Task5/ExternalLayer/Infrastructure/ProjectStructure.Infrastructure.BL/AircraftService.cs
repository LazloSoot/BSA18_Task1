using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Infrastructure.BL
{
    public class AircraftService : IAircraftService
    {
        private readonly IDbAircraftUnitOfWork uow;
        public AircraftService(IDbAircraftUnitOfWork aircraftUnitOfWork)
        {
            uow = aircraftUnitOfWork;
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
            var item = uow.Planes.Insert(plane);
            if (item == null)
                return null;
            else
                uow.SaveChanges();
                return item;
        }

        public Plane GetPlaneInfo(long id)
        {
            return uow.Planes.Get(id) ?? null;
        }

        public IEnumerable<Plane> GetAllPlanesInfo()
        {
            return uow.Planes.GetAll() ?? null;
        }

        public Plane ModifyPlaneInfo(Plane plane)
        {
            var item = uow.Planes.Update(plane);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public bool TryDeletePlane(int id)
        {
            if(uow.Planes.Delete(id))
            {
                uow.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region PlaneTypes Methods

        public PlaneType AddPlaneType(PlaneType type)
        {
            var item = uow.PlaneTypes.Insert(type);
            if (item == null)
                return null;
            else
                uow.SaveChanges();
            return item;
        }

        public IEnumerable<PlaneType> GetAllPlaneTypesInfo()
        {
            return uow.PlaneTypes.GetAll() ?? null;
        }

        public PlaneType GetPlaneTypeInfo(int id)
        {
            return uow.PlaneTypes.Get(id) ?? null;
        }

        public PlaneType ModifyPlaneType(PlaneType type)
        {
            var item = uow.PlaneTypes.Update(type);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public bool TryDeletePlaneType(int id)
        {
            if (uow.PlaneTypes.Delete(id))
            {
                uow.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion
    }
}
