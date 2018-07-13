using System;
using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Aircraft
{
    public class AircraftUnitOfWork : IAircraftUnitOfWork
    {
        private readonly object DBContext;

        public IRepository<Plane> Planes { get; }
        public IRepository<PlaneType> PlaneTypes { get; }

        public AircraftUnitOfWork(IRepository<Plane> planesRepository, IRepository<PlaneType> planeTypeRepository)
        {
            Planes = planesRepository;
            PlaneTypes = planeTypeRepository;
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
