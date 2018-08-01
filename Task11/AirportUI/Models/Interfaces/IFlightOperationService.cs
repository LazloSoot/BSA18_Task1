using AirportUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AirportUI.Models.Interfaces
{
    public interface IFlightOperationService
    {
        Flight AddFlight(Flight flight);
        Task<Flight> AddFlightAsync(Flight flight, CancellationToken ct);
        Ticket AddTicket(Ticket ticket);
        Task<Ticket> AddTicketAsync(Ticket ticket, CancellationToken ct);
        IEnumerable<Departure> GetAllDeparturesInfo();
        Task<IEnumerable<Departure>> GetAllDeparturesInfoAsync(CancellationToken ct);
        IEnumerable<Flight> GetAllFlightsInfo();
        Task<IEnumerable<Flight>> GetAllFlightsInfoAsync(CancellationToken ct);
        IEnumerable<Ticket> GetAllTicketsInfo();
        Task<IEnumerable<Ticket>> GetAllTicketsInfoAsync(CancellationToken ct);
        Departure GetDepartureInfo(long id);
        Task<Departure> GetDepartureInfoAsync(long id, CancellationToken ct);
        IEnumerable<Departure> GetDeparturesByInclude(Expression<Func<Departure, bool>> predicate, bool isCached = false, params Expression<Func<Departure, object>>[] includeProperties);
        IEnumerable<Departure> GetFlightDepartureInfo(long id);
        Task<IEnumerable<Departure>> GetFlightDepartureInfoAsync(long id, CancellationToken ct);
        Flight GetFlightIncludeTickets(long id, bool isCatched = false);
        Flight GetFlightInfo(long id);
        Task<Flight> GetFlightInfoAsync(long id, CancellationToken ct);
        IEnumerable<Ticket> GetFlightTicketsInfo(long id);
        Task<IEnumerable<Ticket>> GetFlightTicketsInfoAsync(long id, CancellationToken ct);
        Ticket GetTicketInfo(long id);
        Task<Ticket> GetTicketInfoAsync(long id, CancellationToken ct);
        Flight ModifyFlight(long id, Flight flight);
        Task<Flight> ModifyFlightAsync(long id, Flight flight, CancellationToken ct);
        Ticket ModifyTicket(long id, Ticket ticket);
        Task<Ticket> ModifyTicketAsync(long id, Ticket ticket, CancellationToken ct);
        bool TryCancelDeparture(long id);
        Task<bool> TryCancelDepartureAsync(long id, CancellationToken ct);
        bool TryCancelFlight(long id);
        Task<bool> TryCancelFlightAsync(long id, CancellationToken ct);
        bool TryDeleteTicket(long id);
        Task<bool> TryDeleteTicketAsync(long id, CancellationToken ct);
        Departure UpdateDepartureInfo(long id, Departure departure);
        Task<Departure> UpdateDepartureInfoAsync(long id, Departure departure, CancellationToken ct);

    }
}
