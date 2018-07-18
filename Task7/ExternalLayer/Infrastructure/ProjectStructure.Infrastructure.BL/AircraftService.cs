using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Linq;

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

        public CheckNeeded GetPlaneTechCondition(long id)
        {
            var plane = uow.Planes.Get(id);
            if (plane == null)
                throw new ArgumentException($"Plane with id = {id} not found!");

            return GetPlaneTechCondition(plane);
        }

        public CheckNeeded GetPlaneTechCondition(Plane plane)
        {
            if (plane == null)
                throw new ArgumentNullException("Plane is null");

            // каждые 12 лет
            if (DateTime.Now - plane.LastHeavyMaintenance >= TimeSpan.FromDays(4380))
                return CheckNeeded.D_Check;
            else if (plane.FlightHours >= 7500)
                return CheckNeeded.C_Check;
            else if (plane.FlightHours >= 3000)
                return CheckNeeded.B_Check;
            else if (plane.FlightHours >= 500)
                return CheckNeeded.A_Check;
            else
                return CheckNeeded.None;
        }

        public Plane CarryOutMaintenance(Plane plane, CheckNeeded checks)
        {
            if (plane == null)
                throw new ArgumentNullException("Plane is null");
            if (checks == CheckNeeded.None)
                return plane;

            switch (checks)
            {
                case CheckNeeded.A_Check:
                    Debug.WriteLine("A-check started.");
                    Thread.Sleep(750);
                    Debug.WriteLine("A-check successfuly completed.");
                    break;
                case CheckNeeded.B_Check:
                    Debug.WriteLine("B-check started.");
                    Thread.Sleep(1250);
                    Debug.WriteLine("B-check successfuly completed.");
                    break;
                case CheckNeeded.C_Check:
                    Debug.WriteLine("C-check started.");
                    Thread.Sleep(2000);
                    plane.FlightHours = 0;
                    Debug.WriteLine("C-check successfuly completed.");
                    break;
                case CheckNeeded.D_Check:
                    Debug.WriteLine("D-check started.");
                    Thread.Sleep(4000);
                    plane.LastHeavyMaintenance = DateTime.Now;
                    plane.FlightHours = 0;
                    Debug.WriteLine("D-check successfuly completed.");
                    break;
                default:
                    break;
            }

            return plane;
        }

        public Plane AddPlane(Plane plane)
        {
            Plane item = null; ;
            if (plane.Type != null)
                item = uow.Planes.Insert(plane);
            else if (!plane.TypeId.HasValue)
                return null;
            else if (GetPlaneTypeInfo(plane.TypeId.Value) != null)
                item = uow.Planes.Update(plane);

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

        public Plane GetPlaneInfoIncluded(long id)
        {
            return uow.Planes.FindByInclude(p => p.Id == id, false, p => p.Type)
                .FirstOrDefault()
                ?? null;
        }

        public IEnumerable<Plane> GetAllPlanesInfo()
        {
            return uow.Planes.GetAll() ?? null;
        }

        public Plane ModifyPlaneInfo(long id, Plane plane)
        {
            plane.Id = id;
            var item = uow.Planes.Update(plane);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public bool TryDeletePlane(long id)
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

        public PlaneType GetPlaneTypeInfo(long id)
        {
            return uow.PlaneTypes.Get(id) ?? null;
        }

        public PlaneType ModifyPlaneType(long id, PlaneType type)
        {
            type.Id = id;
            var item = uow.PlaneTypes.Update(type);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public bool TryDeletePlaneType(long id)
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
