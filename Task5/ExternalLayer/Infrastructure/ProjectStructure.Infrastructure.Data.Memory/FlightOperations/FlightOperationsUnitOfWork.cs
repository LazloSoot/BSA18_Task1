using System;
using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class FlightOperationsUnitOfWork : IFlightOperationsUnitOfWork
    {
        private readonly AirportContext dbContext;

        public IRepository<Flight> Flights { get; }
        public IRepository<Ticket> Tickets { get; }
        public IRepository<Departure> Departures { get; }

        public FlightOperationsUnitOfWork(IRepository<Flight> flightsRepository, IRepository<Ticket> ticketsRepository,
            IRepository<Departure> departuresRepository,
              AirportContext context
            )
        {
            Departures = departuresRepository;
            Flights = flightsRepository;
            Tickets = ticketsRepository;
            dbContext = context;
        }


        public void Dispose()
        {
            
        }

        public int SaveChanges()
        {
            return -1;
        }

        public Task<int> SaveChangesAsync()
        {
            return null;
        }
    }
}
