using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ProjectStructure.Domain;

namespace ProjectStructure.Services.Interfaces
{
    /// <summary>
    /// Сервис организации полетов.
    /// </summary>
    public interface IFlightOperationsService
    {
        #region Flights

        IEnumerable<Flight> GetAllFlightsInfo();

        Task<IEnumerable<Flight>> GetAllFlightsInfoAsync(CancellationToken ct = default(CancellationToken));

        Flight GetFlightInfo(long id);

        Task<Flight> GetFlightInfoAsync(long id, CancellationToken ct = default(CancellationToken));

        Flight GetFlightIncludeTickets(long id, bool isCatched = false);

        Flight AddFlight(Flight flight);

        Task<Flight> AddFlightAsync(Flight flight, CancellationToken ct = default(CancellationToken));

        Flight ModifyFlight(long id, Flight flight);

        Task<Flight> ModifyFlightAsync(long id, Flight flight, CancellationToken ct = default(CancellationToken));

        bool TryCancelFlight(long id);

        Task<bool> TryCancelFlightAsync(long id, CancellationToken ct = default(CancellationToken));

        #endregion

        #region Departures

        IEnumerable<Departure> GetAllDeparturesInfo();

        Task<IEnumerable<Departure>> GetAllDeparturesInfoAsync(CancellationToken ct = default(CancellationToken));

        IEnumerable<Departure> GetFlightDepartureInfo(long id);

        Task<IEnumerable<Departure>> GetFlightDepartureInfoAsync(long id, CancellationToken ct = default(CancellationToken));

        IEnumerable<Departure> GetDeparturesByInclude(Expression<Func<Departure, bool>> predicate, bool isCached = false, params Expression<Func<Departure, object>>[] includeProperties);

        Departure GetDepartureInfo(long id);

        Task<Departure> GetDepartureInfoAsync(long id, CancellationToken ct = default(CancellationToken));

        // Departure SheduleDeparture(Departure departure);

        Departure UpdateDepartureInfo(long id, Departure departure);

        Task<Departure> UpdateDepartureInfoAsync(long id, Departure departure, CancellationToken ct = default(CancellationToken));

        bool TryCancelDeparture(long id);

        Task<bool> TryCancelDepartureAsync(long id, CancellationToken ct = default(CancellationToken));

        #endregion

        #region Tickets
        
        IEnumerable<Ticket> GetAllTicketsInfo();

        Task<IEnumerable<Ticket>> GetAllTicketsInfoAsync(CancellationToken ct = default(CancellationToken));

        IEnumerable<Ticket> GetFlightTicketsInfo(long id);

        Task<IEnumerable<Ticket>> GetFlightTicketsInfoAsync(long id, CancellationToken ct = default(CancellationToken));

        Ticket GetTicketInfo(long id);

        Task<Ticket> GetTicketInfoAsync(long id, CancellationToken ct = default(CancellationToken));

        Ticket AddTicket(Ticket ticket);

        Task<Ticket> AddTicketAsync(Ticket ticket, CancellationToken ct = default(CancellationToken));

        Ticket ModifyTicket(long id, Ticket ticket);

        Task<Ticket> ModifyTicketAsync(long id, Ticket ticket, CancellationToken ct = default(CancellationToken));

        bool TryDeleteTicket(long id);

        Task<bool> TryDeleteTicketAsync(long id, CancellationToken ct = default(CancellationToken));

        #endregion
    }
}
