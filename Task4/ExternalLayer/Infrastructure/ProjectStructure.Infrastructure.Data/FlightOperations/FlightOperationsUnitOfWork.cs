using System;
using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.FlightOperations
{
    public class FlightOperationsUnitOfWork : IFlightOperationsUnitOfWork
    {
        private readonly object dbContext;

        public IRepository<Flight> Flights { get; }
        public IRepository<Ticket> Tickets { get; }
        public IRepository<Departure> Departures { get; }

        public FlightOperationsUnitOfWork(IRepository<Flight> flightsRepository, IRepository<Ticket> ticketsRepository,
            IRepository<Departure> departuresRepository)
        {
            Departures = departuresRepository;
            Flights = flightsRepository;
            Tickets = ticketsRepository;
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
