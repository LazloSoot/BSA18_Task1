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
        
        public abstract IEnumerable<Ticket> CreateFlight(Flight flightInfo, Departure departureInfo);

        public abstract IEnumerable<Ticket> CreateFlight(long flightId, long departureId);
    }
}
