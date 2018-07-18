using System.Threading;
using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Aircraft
{
    public class AircraftUnitOfWork : IDbAircraftUnitOfWork
    {
        private readonly AirportContext dbContext;

        public IDbRepository<Plane> Planes { get; }
        public IDbRepository<PlaneType> PlaneTypes { get; }

        public AircraftUnitOfWork(EFRepository<Plane> planesRepository, EFRepository<PlaneType> planeTypeRepository,
          AirportContext context
          )
        {
            planesRepository.DbContext = context;
            planeTypeRepository.DbContext = context;
            dbContext = context;

            Planes = planesRepository;
            PlaneTypes = planeTypeRepository;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default(CancellationToken))
        {
            return await dbContext.SaveChangesAsync(ct);
        }
        
    }
}
