using AirportUI.Models.Entities;
using AirportUI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AirportUI.Models
{
    public class FlightOperationsService : IFlightOperationService
    {
        public Flight AddFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task<Flight> AddFlightAsync(Flight flight, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Ticket AddTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> AddTicketAsync(Ticket ticket, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Departure> GetAllDeparturesInfo()
        {
            return null;
#if DEBUGNOSERVER

            return 
#endif
        }

        public Task<IEnumerable<Departure>> GetAllDeparturesInfoAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetAllFlightsInfo()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Flight>> GetAllFlightsInfoAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAllTicketsInfo()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAllTicketsInfoAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Departure GetDepartureInfo(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Departure> GetDepartureInfoAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Departure> GetDeparturesByInclude(Expression<Func<Departure, bool>> predicate, bool isCached = false, params Expression<Func<Departure, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Departure> GetFlightDepartureInfo(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Departure>> GetFlightDepartureInfoAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Flight GetFlightIncludeTickets(long id, bool isCatched = false)
        {
            throw new NotImplementedException();
        }

        public Flight GetFlightInfo(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Flight> GetFlightInfoAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetFlightTicketsInfo(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetFlightTicketsInfoAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketInfo(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetTicketInfoAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Flight ModifyFlight(long id, Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task<Flight> ModifyFlightAsync(long id, Flight flight, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Ticket ModifyTicket(long id, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> ModifyTicketAsync(long id, Ticket ticket, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public bool TryCancelDeparture(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TryCancelDepartureAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public bool TryCancelFlight(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TryCancelFlightAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public bool TryDeleteTicket(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TryDeleteTicketAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Departure UpdateDepartureInfo(long id, Departure departure)
        {
            throw new NotImplementedException();
        }

        public Task<Departure> UpdateDepartureInfoAsync(long id, Departure departure, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
