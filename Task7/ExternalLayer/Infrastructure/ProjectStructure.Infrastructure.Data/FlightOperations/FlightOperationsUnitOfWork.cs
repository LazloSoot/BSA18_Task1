using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.FlightOperations
{
    public class FlightOperationsUnitOfWork : IDbFlightOperationsUnitOfWork
    {
        private readonly AirportContext dbContext;

        public IDbRepository<Flight> Flights { get; }
        public IDbRepository<Ticket> Tickets { get; }
        public IDbRepository<Departure> Departures { get; }

        public FlightOperationsUnitOfWork(EFRepository<Flight> flightsRepository, EFRepository<Ticket> ticketsRepository,
            EFRepository<Departure> departuresRepository,
            AirportContext context
            )
        {
            flightsRepository.DbContext = context;
            ticketsRepository.DbContext = context;
            departuresRepository.DbContext = context;
            dbContext = context;
            Departures = departuresRepository;
            Flights = flightsRepository;
            Tickets = ticketsRepository;
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
            return await dbContext.SaveChangesAsync();
        }
    }
}
