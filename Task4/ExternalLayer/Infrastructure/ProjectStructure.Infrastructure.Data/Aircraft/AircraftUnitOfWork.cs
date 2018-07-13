using System;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Aircraft
{
    public class AircraftUnitOfWork : IAircraftUnitOfWork
    {
        private readonly AirportContext dbContext;

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
