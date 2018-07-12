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

        Flight GetFlightInfo(int id);

        Flight AddFlight(Flight flight);

        Flight ModifyFlight(Flight flight);

        bool TryCancelFlight(int id);

        #endregion

        #region Departures

        IEnumerable<Departure> GetAllDeparturesInfo();

        Departure GetDepartureInfo(int id);

        Departure SheduleDeparture(Departure departure);

        Departure UpdateDepartureInfo(Departure departure);

        Departure TryCancelDeparture(int id);

        #endregion

        #region Tickets

        IEnumerable<Ticket> GetAllTicketsInfo();

        Ticket GetFlightTicketsInfo(int id);

        Ticket GetTicketInfo(int id);

        Ticket AddTicket(Ticket ticket);

        Ticket ModifyTicket(Ticket ticket);

        bool TryDeleteTicket(int id);

        #endregion
    }
}
