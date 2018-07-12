using ProjectStructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Services.Interfaces
{
    public abstract class Airport
    {
        public IAircraftService AircraftService { get; }
        public ICrewingService CrewingService { get; }
        public IFlightOperationsService FlightOperationsService { get; }

        public Airport(IAircraftService aircraftService, ICrewingService crewingService,
            IFlightOperationsService flightOperationsService)
        {
            AircraftService = aircraftService;
            CrewingService = crewingService;
            FlightOperationsService = flightOperationsService;
        }

#warning Будет использовать так раз DTO !!!!!!!!11111111111
        public abstract IEnumerable<Ticket> CreateFlight(Flight flightInfo, Departure departureInfo);

        public abstract IEnumerable<Ticket> CreateFlight(long flightId, long departureId);
    }
}
