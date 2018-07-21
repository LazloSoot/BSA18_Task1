using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        Flight GetFlightInfo(long id);

        Flight GetFlightIncludeTickets(long id, bool isCatched = false);

        Flight AddFlight(Flight flight);

        Flight ModifyFlight(long id, Flight flight);

        bool TryCancelFlight(long id);

        #endregion

        #region Departures

        IEnumerable<Departure> GetAllDeparturesInfo();

        IEnumerable<Departure> GetFlightDepartureInfo(long id);

        IEnumerable<Departure> GetDeparturesByInclude(Expression<Func<Departure, bool>> predicate, bool isCached = false, params Expression<Func<Departure, object>>[] includeProperties);

        Departure GetDepartureInfo(long id);

       // Departure SheduleDeparture(Departure departure);

        Departure UpdateDepartureInfo(long id, Departure departure);

        bool TryCancelDeparture(long id);

        #endregion

        #region Tickets

        IEnumerable<Ticket> GetAllTicketsInfo();

        IEnumerable<Ticket> GetFlightTicketsInfo(int id);

        Ticket GetTicketInfo(int id);

        Ticket AddTicket(Ticket ticket);

        Ticket ModifyTicket(long id, Ticket ticket);

        bool TryDeleteTicket(int id);

        #endregion
    }
}
