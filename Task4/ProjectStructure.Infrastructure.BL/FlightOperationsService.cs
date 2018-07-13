using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;
using ProjectStructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Infrastructure.BL
{
    public class FlightOperationsService : IFlightOperationsService
    {
        private readonly IUnitOfWork uow;
        #region Flights

        public Flight GetFlightInfo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetAllFlightsInfo()
        {
            throw new NotImplementedException();
        }

        public Flight AddFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Flight ModifyFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public bool TryCancelFlight(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Departures

        public Departure GetDepartureInfo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Departure> GetAllDeparturesInfo()
        {
            throw new NotImplementedException();
        }

        public Departure SheduleDeparture(Departure departure)
        {
            throw new NotImplementedException();
        }
        public Departure UpdateDepartureInfo(Departure departure)
        {
            throw new NotImplementedException();
        }

        public Departure TryCancelDeparture(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Tickets

        public Ticket GetTicketInfo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAllTicketsInfo()
        {
            throw new NotImplementedException();
        }

        public Ticket GetFlightTicketsInfo(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket AddTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Ticket ModifyTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public bool TryDeleteTicket(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
