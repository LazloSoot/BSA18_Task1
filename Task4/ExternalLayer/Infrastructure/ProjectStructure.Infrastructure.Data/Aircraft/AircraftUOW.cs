using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Aircraft
{
    public class AircraftUOW : IUnitOfWork
    {
        private readonly object DBContext;
        private readonly IRepository<Plane> planes;
        private readonly IRepository<PlaneType> planeTypes;

        public AircraftUOW(IRepository<Plane> planesRepository, IRepository<PlaneType> planeTypeRepository)
        {
            planes = planesRepository;
            planeTypes = planeTypeRepository;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IRepository<T> Set<T>() where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
