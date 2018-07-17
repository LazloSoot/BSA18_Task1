using ProjectStructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Services.Interfaces
{
    public abstract class Airport
    {
        protected IAircraftService AircraftService { get; }
        protected ICrewingService CrewingService { get; }
        protected IFlightOperationsService FlightOperationsService { get; }

        public Airport(IAircraftService aircraftService, ICrewingService crewingService,
            IFlightOperationsService flightOperationsService)
        {
            AircraftService = aircraftService;
            CrewingService = crewingService;
            FlightOperationsService = flightOperationsService;
        }

        public abstract Departure SheduleDeparture(Departure departureInfo);

        public abstract Departure ModifyDeparture(Departure departureInfo);

        public abstract bool DeleteDeparture(long id);

        public abstract Flight ModifyFlight(Flight flight);

        public abstract bool DeleteFlight(long id);

        public abstract Ticket AddTicket(Ticket ticket);
    }
}
