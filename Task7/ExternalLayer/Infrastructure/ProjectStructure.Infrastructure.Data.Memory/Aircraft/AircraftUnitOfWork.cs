using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Memory
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
            return -1;
        }

        public  Task<int> SaveChangesAsync()
        {
            return null;
        }
        
    }
}
