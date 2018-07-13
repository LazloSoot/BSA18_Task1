using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.Data.FlightOperations
{
    public class FlightOperationsUOW : IUnitOfWork
    {
        private readonly object dbContext;
        private readonly IRepository<Flight> flights;
        private readonly IRepository<Departure> departures;
        private readonly IRepository<Ticket> tickets;


        public FlightOperationsUOW(IRepository<Flight> flightsRepository, IRepository<Ticket> ticketsRepository,
            IRepository<Departure> departuresRepository)
        {
            departures = departuresRepository;
            flights = flightsRepository;
            tickets = ticketsRepository;
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
