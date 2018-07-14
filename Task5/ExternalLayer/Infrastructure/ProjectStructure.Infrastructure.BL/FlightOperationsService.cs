using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;
using ProjectStructure.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Infrastructure.BL
{
    public class FlightOperationsService : IFlightOperationsService
    {
        private readonly IFlightOperationsUnitOfWork uow;

        public FlightOperationsService(IFlightOperationsUnitOfWork flightOperationsUnitOfWork)
        {
            uow = flightOperationsUnitOfWork;
        }

        #region Flights

        public Flight GetFlightInfo(int id)
        {
            return uow.Flights.Get(id) ?? null;
        }

        public IEnumerable<Flight> GetAllFlightsInfo()
        {
            return uow.Flights.GetAll() ?? null;
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

        public Flight ModifyFlight(Flight flight)
        {
            var item = uow.Flights.Update(flight);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public bool TryCancelFlight(int id)
        {
            if (uow.Flights.Delete(id))
            {
                uow.SaveChanges();
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

        public IEnumerable<Departure> GetFlightDepartureInfo(long id)
        {
            return uow.Departures.GetAll().Where(d => d.Flight.Id == id) ?? null;
        }

        public IEnumerable<Departure> GetAllDeparturesInfo()
        {
            return uow.Departures.GetAll() ?? null;
        }

        public Departure SheduleDeparture(Departure departure)
        {
            var item = uow.Departures.Insert(departure);
            if (item == null)
                return null;
            else
                uow.SaveChanges();
            return item;
        }
        public Departure UpdateDepartureInfo(Departure departure)
        {
            var item = uow.Departures.Update(departure);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
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

        #endregion

        #region Tickets

        public Ticket GetTicketInfo(int id)
        {
            return uow.Tickets.Get(id) ?? null;
        }

        public IEnumerable<Ticket> GetAllTicketsInfo()
        {
            return uow.Tickets.GetAll() ?? null;
        }

        public IEnumerable<Ticket> GetFlightTicketsInfo(int id)
        {
            var flight = uow.Flights.Get(id);
            return flight?.Tickets;
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

        public Ticket ModifyTicket(Ticket ticket)
        {
            var item = uow.Tickets.Update(ticket);
            if (item == null)
                return null;
            else
            {
                uow.SaveChanges();
                return item;
            }
        }

        public bool TryDeleteTicket(int id)
        {
            if (uow.Tickets.Delete(id))
            {
                uow.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion
    }
}
