using ProjectStructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public abstract Task<Departure> SheduleDepartureAsync(Departure departureInfo, CancellationToken ct = default(CancellationToken));

        public abstract Departure ModifyDeparture(long id, Departure departureInfo);

        public abstract Task<Departure> ModifyDepartureAsync(long id, Departure departureInfo, CancellationToken ct = default(CancellationToken));

        public abstract bool DeleteDeparture(long id);

        public abstract Task<bool> DeleteDepartureAsync(long id, CancellationToken ct = default(CancellationToken));

        public abstract Flight ModifyFlight(long id, Flight flight);

        public abstract Task<Flight> ModifyFlightAsync(long id, Flight flight, CancellationToken ct = default(CancellationToken));

        public abstract bool DeleteFlight(long id);

        public abstract Task<bool> DeleteFlightAsync(long id, CancellationToken ct = default(CancellationToken));

        public abstract Ticket AddTicket(Ticket ticket);

        public abstract Task<Ticket> AddTicketAsync(Ticket ticket, CancellationToken ct = default(CancellationToken));
    }
}
