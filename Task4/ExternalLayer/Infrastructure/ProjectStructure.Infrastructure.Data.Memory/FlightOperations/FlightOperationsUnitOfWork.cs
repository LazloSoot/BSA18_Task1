using System;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public class FlightOperationsUnitOfWork : IFlightOperationsUnitOfWork
    {
       // private readonly DbContext dbContext;

        public IRepository<Flight> Flights { get; }
        public IRepository<Ticket> Tickets { get; }
        public IRepository<Departure> Departures { get; }

        public FlightOperationsUnitOfWork(IRepository<Flight> flightsRepository, IRepository<Ticket> ticketsRepository,
            IRepository<Departure> departuresRepository
          //  DbContext context
            )
        {
            Departures = departuresRepository;
            Flights = flightsRepository;
            Tickets = ticketsRepository;
         //   dbContext = context;
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
