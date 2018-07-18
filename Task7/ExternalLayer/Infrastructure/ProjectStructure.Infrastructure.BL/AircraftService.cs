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
using System.Threading.Tasks;

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

        public async Task<Plane> CarryOutMaintenanceAsync(Plane plane, CheckNeeded cheks, CancellationToken ct = default(CancellationToken))
        {
            if (plane == null)
                throw new ArgumentNullException("Plane is null");
            if (cheks == CheckNeeded.None)
                return plane;

            await Task.Run(() => {
                switch (cheks)
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
            });
            
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

        public async Task<Plane> AddPlaneAsync(Plane plane, CancellationToken ct = default(CancellationToken))
        {
            Plane item = null; ;
            if (plane.Type != null)
                item = await uow.Planes.InsertAsync(plane, ct);
            else if (!plane.TypeId.HasValue)
                return null;
            else if (GetPlaneTypeInfoAsync(plane.TypeId.Value, ct) != null)
                item = uow.Planes.Update(plane);

            if (item == null)
                return null;
            else
                await uow.SaveChangesAsync(ct);
            return item;
        }
        
        public Plane GetPlaneInfo(long id)
        {
            return uow.Planes.Get(id) ?? null;
        }

        public async Task<Plane> GetPlaneInfoAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            return await uow.Planes.GetAsync(id, ct);
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

        public async Task<IEnumerable<Plane>> GetAllPlanesInfoAsync(CancellationToken ct = default(CancellationToken))
        {
            return await uow.Planes.GetAllAsync(ct) ?? null;
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

        public async Task<Plane> ModifyPlaneInfoAsync(long id, Plane plane, CancellationToken ct = default(CancellationToken))
        {
            plane.Id = id;
            var item = uow.Planes.Update(plane);
            if (item == null)
                return null;
            else
            {
                await uow.SaveChangesAsync(ct);
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

        public async Task<bool> TryDeletePlaneAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            if (uow.Planes.Delete(id))
            {
                await uow.SaveChangesAsync(ct);
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

        public async Task<PlaneType> AddPlaneTypeAsync(PlaneType type, CancellationToken ct = default(CancellationToken))
        {
            var item = await uow.PlaneTypes.InsertAsync(type, ct);
            if (item == null)
                return null;
            else
                await uow.SaveChangesAsync(ct);
            return item;
        }

        public IEnumerable<PlaneType> GetAllPlaneTypesInfo()
        {
            return uow.PlaneTypes.GetAll() ?? null;
        }

        public async Task<IEnumerable<PlaneType>> GetAllPlaneTypesInfoAsync(CancellationToken ct = default(CancellationToken))
        {
            return await uow.PlaneTypes.GetAllAsync(ct) ?? null;
        }

        public PlaneType GetPlaneTypeInfo(long id)
        {
            return uow.PlaneTypes.Get(id) ?? null;
        }

        public async Task<PlaneType> GetPlaneTypeInfoAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            return await uow.PlaneTypes.GetAsync(id, ct);
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

        public async Task<PlaneType> ModifyPlaneTypeAsync(long id, PlaneType type, CancellationToken ct = default(CancellationToken))
        {
            type.Id = id;
            var item = uow.PlaneTypes.Update(type);
            if (item == null)
                return null;
            else
            {
                await uow.SaveChangesAsync(ct);
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

        public async Task<bool> TryDeletePlaneTypeAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            if (uow.PlaneTypes.Delete(id))
            {
                await uow.SaveChangesAsync(ct);
                return true;
            }
            return false;
        }
        #endregion
    }
}
