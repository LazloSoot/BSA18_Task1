using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Infrastructure.Data
{
    public abstract class EFAircraftUnitOfWorkIAircraftUnitOfWork
    {
        private readonly DbContext dbContext;

        public IRepository<Plane> Planes { get; }
        public IRepository<PlaneType> PlaneTypes { get; }

        public AircraftUnitOfWork(IRepository<Plane> planesRepository, IRepository<PlaneType> planeTypeRepository,
          AirportContext context
          )
        {
            Planes = planesRepository;
            PlaneTypes = planeTypeRepository;
            dbContext = context;
        }



        public void Dispose()
        {
            dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }

    }
}
