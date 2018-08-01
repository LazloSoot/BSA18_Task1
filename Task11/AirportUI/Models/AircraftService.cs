using AirportUI.Models.Entities;
using AirportUI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AirportUI.Models
{
    public class AircraftService : IAircraftService
    {
        public Plane AddPlane(Plane plane)
        {
            throw new NotImplementedException();
        }

        public Task<Plane> AddPlaneAsync(Plane plane, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public PlaneType AddPlaneType(PlaneType type)
        {
            throw new NotImplementedException();
        }

        public Task<PlaneType> AddPlaneTypeAsync(PlaneType type, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plane> GetAllPlanesInfo()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Plane>> GetAllPlanesInfoAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaneType> GetAllPlaneTypesInfo()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlaneType>> GetAllPlaneTypesInfoAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Plane GetPlaneInfo(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Plane> GetPlaneInfoAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Plane GetPlaneInfoIncluded(long id)
        {
            throw new NotImplementedException();
        }

        public PlaneType GetPlaneTypeInfo(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PlaneType> GetPlaneTypeInfoAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Plane ModifyPlaneInfo(long id, Plane plane)
        {
            throw new NotImplementedException();
        }

        public Task<Plane> ModifyPlaneInfoAsync(long id, Plane plane, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public PlaneType ModifyPlaneType(long id, PlaneType type)
        {
            throw new NotImplementedException();
        }

        public Task<PlaneType> ModifyPlaneTypeAsync(long id, PlaneType type, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public bool TryDeletePlane(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TryDeletePlaneAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public bool TryDeletePlaneType(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TryDeletePlaneTypeAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
