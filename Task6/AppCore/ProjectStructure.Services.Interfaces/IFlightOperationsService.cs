using System.Collections.Generic;
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

        Flight AddFlight(Flight flight);

        Flight ModifyFlight(Flight flight);

        bool TryCancelFlight(long id);

        #endregion

        #region Departures

        IEnumerable<Departure> GetAllDeparturesInfo();

        IEnumerable<Departure> GetFlightDepartureInfo(long id);

        Departure GetDepartureInfo(long id);

        Departure SheduleDeparture(Departure departure);

        Departure UpdateDepartureInfo(Departure departure);

        bool TryCancelDeparture(long id);

        #endregion

        #region Tickets

        IEnumerable<Ticket> GetAllTicketsInfo();

        IEnumerable<Ticket> GetFlightTicketsInfo(int id);

        Ticket GetTicketInfo(int id);

        Ticket AddTicket(Ticket ticket);

        Ticket ModifyTicket(Ticket ticket);

        bool TryDeleteTicket(int id);

        #endregion
    }
}
