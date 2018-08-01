using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;
using ProjectStructure.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStructure.Infrastructure.BL
{
    public class FlightOperationsService : IFlightOperationsService
    {
        private readonly IDbFlightOperationsUnitOfWork uow;

        public FlightOperationsService(IDbFlightOperationsUnitOfWork flightOperationsUnitOfWork)
        {
            uow = flightOperationsUnitOfWork;
        }

        #region Flights

        public Flight GetFlightInfo(long id)
        {
            return uow.Flights.Get(id) ?? null;
        }

        public async Task<Flight> GetFlightInfoAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            return await uow.Flights.GetAsync(id, ct) ?? null;
        }

        public IEnumerable<Flight> GetAllFlightsInfo()
        {
            return uow.Flights.GetAll() ?? null;
        }

        public async Task<IEnumerable<Flight>> GetAllFlightsInfoAsync(CancellationToken ct = default(CancellationToken))
        {
            return await uow.Flights.GetAllAsync(ct) ?? null;
        }

        public Flight GetFlightIncludeTickets(long id, bool isCatched = false)
        {
            return uow.Flights.FindByInclude(f => f.Id == id, isCatched, f => f.Tickets)
                .FirstOrDefault() 
                ?? null;
        }

        public Flight AddFlight(Flight flight)
        {
            var item = uow.Flights.Insert(flight);
            if (item == null)
                return null;
            else
                uow.SaveChanges();
            return item;
        }

        public async Task<Flight> AddFlightAsync(Flight flight, CancellationToken ct = default(CancellationToken))
        {
            var item = await uow.Flights.InsertAsync(flight, ct);
            if (item == null)
                return null;
            else
                await uow.SaveChangesAsync(ct);
            return item;
        }

        public Flight ModifyFlight(long id, Flight flight)
        {
            flight.Id = id;
            var item = uow.Flights.Update(flight);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public async Task<Flight> ModifyFlightAsync(long id, Flight flight, CancellationToken ct = default(CancellationToken))
        {
            flight.Id = id;
            var item = uow.Flights.Update(flight);
            if (item == null)
                return null;
            else
            {
                await uow.SaveChangesAsync(ct);
                return item;
            }
        }

        public bool TryCancelFlight(long id)
        {
            if (uow.Flights.Delete(id))
            {
                uow.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> TryCancelFlightAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            if (uow.Flights.Delete(id))
            {
                await uow.SaveChangesAsync(ct);
                return true;
            }
            return false;
        }

        #endregion

        #region Departures

        public Departure GetDepartureInfo(long id)
        {
            return uow.Departures.Get(id) ?? null;
        }

        public async Task<Departure> GetDepartureInfoAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            return await uow.Departures.GetAsync(id, ct);
        }

        public IEnumerable<Departure> GetFlightDepartureInfo(long id)
        {
            return uow.Departures.GetAll().Where(d => d.Flight.Id == id) ?? null;
        }

        public async Task<IEnumerable<Departure>> GetFlightDepartureInfoAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            var dep = await uow.Departures.GetAllAsync(ct);
            return dep.Where(d => d.Flight.Id == id) ?? null;
        }

        public IEnumerable<Departure> GetDeparturesByInclude(Expression<Func<Departure, bool>> predicate, bool isCached = false, params Expression<Func<Departure, object>>[] includeProperties)
        {
            return uow.Departures.FindByInclude(predicate, isCached, includeProperties) ?? null;
        }

        public IEnumerable<Departure> GetAllDeparturesInfo()
        {
            return uow.Departures.GetAll() ?? null;
        }

        public async Task<IEnumerable<Departure>> GetAllDeparturesInfoAsync(CancellationToken ct = default(CancellationToken))
        {
            return await uow.Departures.GetAllAsync(ct) ?? null;
        }

        public Departure UpdateDepartureInfo(long id, Departure departure)
        {
            departure.Id = id;
            var item = uow.Departures.Update(departure);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public async Task<Departure> UpdateDepartureInfoAsync(long id, Departure departure, CancellationToken ct = default(CancellationToken))
        {
            departure.Id = id;
            var item = uow.Departures.Update(departure);
            if (item == null)
                return null;
            else
            {
                await uow.SaveChangesAsync(ct);
                return item;
            }
        }

        public bool TryCancelDeparture(long id)
        {
            if (uow.Departures.Delete(id))
            {
                uow.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> TryCancelDepartureAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            if (uow.Departures.Delete(id))
            {
                await uow.SaveChangesAsync(ct);
                return true;
            }
            return false;
        }
        
        #endregion

        #region Tickets

        public Ticket GetTicketInfo(long id)
        {
            return uow.Tickets.Get(id) ?? null;
        }

        public Task<Ticket> GetTicketInfoAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAllTicketsInfo()
        {
            return uow.Tickets.GetAll() ?? null;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsInfoAsync(CancellationToken ct = default(CancellationToken))
        {
            return await uow.Tickets.GetAllAsync(ct);
        }

        public IEnumerable<Ticket> GetFlightTicketsInfo(long id)
        {
            var flight = uow.Flights
                .FindByInclude(f => f.Id == id, false, f => f.Tickets)
                .FirstOrDefault();
            return flight?.Tickets;
        }

        public async Task<IEnumerable<Ticket>> GetFlightTicketsInfoAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Ticket AddTicket(Ticket ticket)
        {
            var item = uow.Tickets.Insert(ticket);
            if (item == null)
                return null;
            else
                uow.SaveChanges();
            return item;
        }
        
        public async Task<Ticket> AddTicketAsync(Ticket ticket, CancellationToken ct = default(CancellationToken))
        {
            var item = await uow.Tickets.InsertAsync(ticket, ct);
            if (item == null)
                return null;
            else
                await uow.SaveChangesAsync(ct);
            return item;
        }

        public Ticket ModifyTicket(long id, Ticket ticket)
        {
            ticket.Id = id;
            var item = uow.Tickets.Update(ticket);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public async Task<Ticket> ModifyTicketAsync(long id, Ticket ticket, CancellationToken ct = default(CancellationToken))
        {
            ticket.Id = id;
            var item = uow.Tickets.Update(ticket);
            if (item == null)
                return null;
            else
            {
                await uow.SaveChangesAsync(ct);
                return item;
            }
        }

        public bool TryDeleteTicket(long id)
        {
            if (uow.Tickets.Delete(id))
            {
                uow.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> TryDeleteTicketAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            if (uow.Tickets.Delete(id))
            {
                await uow.SaveChangesAsync(ct);
                return true;
            }
            return false;
        }

        #endregion
    }
}
