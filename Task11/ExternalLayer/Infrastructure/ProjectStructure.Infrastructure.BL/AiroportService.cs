using System;
using System.Collections.Generic;
using System.Text;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStructure.Infrastructure.BL
{
    public class AiroportService : Airport
    {
        private double ticketPriceBase = 120.0d;
        private const double priceDeltaConnst = 15.75d;
        private double ticketPriceDelta;

        public AiroportService(IAircraftService aircraftService, ICrewingService crewingService,
           IFlightOperationsService flightOperationsService)
            :base(aircraftService, crewingService, flightOperationsService)
        {
            ticketPriceDelta = ticketPriceBase / 100 * 48 + priceDeltaConnst;
        }
        

        public override Departure SheduleDeparture(Departure departureInfo)
        {
            if (departureInfo == null)
                throw new ArgumentNullException("Departure info is null!");

            Flight currentFlight;
            Crew currentCrew;
            Plane currentPlane;

            #region Проверка рейса

            // проверяем рейс
            if (departureInfo.Flight == null)
            {
                if (departureInfo.FlightId.HasValue)
                {
                    // проверить есть ли рейс
                    currentFlight = FlightOperationsService.GetFlightInfo(departureInfo.FlightId.Value);
                    if (currentFlight == null)
                        throw new ArgumentException($"Flight with id = {departureInfo.FlightId.Value} not found!");
                }
                else
                {
                    throw new ArgumentNullException("Flight have to be specified!");
                }
            }
            else
            {
                if(FlightOperationsService.GetFlightInfo(departureInfo.Flight.Id) == null)
                    throw new ArgumentException($"Flight with id = {departureInfo.Flight.Id} is not exist in db!You need to add this flight first!");

                currentFlight = departureInfo.Flight;
            }

            // сверяем время вылета
            if (currentFlight.DepartureTime != departureInfo.DepartureTime)
                throw new ArgumentException("Date/time of departure does not correspond to the time specified in flight!");

            departureInfo.FlightId = currentFlight.Id;
            departureInfo.Flight = null;

            #endregion

            #region Проверка состояния самолета

            // проверяем состояние самолета
            if (departureInfo.Plane == null)
            {
                if (departureInfo.PlaneId.HasValue)
                {
                    currentPlane = AircraftService.GetPlaneInfoIncluded(departureInfo.PlaneId.Value);
                    if (currentPlane == null)
                        throw new ArgumentException($"Plane with id = {departureInfo.CrewId.Value} not found!");
                }
                else
                {
                    throw new ArgumentNullException("There is no flight crew been assigned!");
                }
            }
            else
            {
                if (AircraftService.GetPlaneInfo(departureInfo.Plane.Id) == null)
                    throw new ArgumentException($"Plane with id = {departureInfo.FlightId.Value} is not exist in db!You need to add this plane first!");

                currentPlane = departureInfo.Plane;
            }

            if(currentPlane.Type == null)
                throw new ArgumentException("Information about plane type not found!");

            // проверить срок службы самолета
            if (DateTime.Now - currentPlane.ReleaseDate >= currentPlane.Lifetime)
                throw new ArgumentException("The lifetime of plane has expired!");

            // проверить необходимость тех обслуживания
            var checksNeeded = AircraftService.GetPlaneTechCondition(currentPlane);
            if (checksNeeded != CheckNeeded.None)
            {
                // тех. обслуживание
                currentPlane = AircraftService.CarryOutMaintenance(currentPlane, checksNeeded);
            }

            departureInfo.PlaneId = currentPlane.Id;
            departureInfo.Plane = null;

            #endregion

            #region Проверка экипажа

            // проверяем экипаж
            if (departureInfo.Crew == null)
            {
                if (departureInfo.CrewId.HasValue)
                {
                    // проверить есть ли сформированая команда
                    currentCrew = CrewingService.GetIncludedCrewInfo(departureInfo.CrewId.Value, false);
                    if (currentCrew == null)
                        throw new ArgumentException($"Crew with id = {departureInfo.CrewId.Value} not found!");
                }
                else
                {
                    throw new ArgumentNullException("There is no flight crew been assigned!");
                }
            }
            else
            {
                currentCrew = departureInfo.Crew;
            }

            // проверяем экипаж
            if (currentCrew.Pilot == null)
                throw new ArgumentException("There is no pilot assigned to flight!");
            else if (currentCrew.Pilot.ExperienceYears < 2)
                throw new ArgumentException("Fly a passenger plane can only pilot with experience at least a two years!");
            if (currentCrew.Stewardesses == null || currentCrew.Stewardesses.Count < 2)
                throw new ArgumentException("There must be at least two stewardesses in the team!");

            departureInfo.CrewId = currentCrew.Id;
            departureInfo.Crew = null;

            #endregion

            GenerateTicketsToFlight(currentFlight, currentPlane.Type.Capacity);
            return FlightOperationsService.UpdateDepartureInfo(departureInfo.Id, departureInfo);
        }

        public override async Task<Departure> SheduleDepartureAsync(Departure departureInfo, CancellationToken ct = default(CancellationToken))
        {
            if (departureInfo == null)
                throw new ArgumentNullException("Departure info is null!");

            Flight currentFlight;
            Crew currentCrew;
            Plane currentPlane;

            #region Проверка рейса

            // проверяем рейс
            if (departureInfo.Flight == null)
            {
                if (departureInfo.FlightId.HasValue)
                {
                    // проверить есть ли рейс
                    currentFlight = await FlightOperationsService.GetFlightInfoAsync(departureInfo.FlightId.Value, ct);
                    if (currentFlight == null)
                        throw new ArgumentException($"Flight with id = {departureInfo.FlightId.Value} not found!");
                }
                else
                {
                    throw new ArgumentNullException("Flight have to be specified!");
                }
            }
            else
            {
                if ((await FlightOperationsService.GetFlightInfoAsync(departureInfo.Flight.Id, ct)) == null)
                    throw new ArgumentException($"Flight with id = {departureInfo.Flight.Id} is not exist in db!You need to add this flight first!");

                currentFlight = departureInfo.Flight;
            }

            // сверяем время вылета
            if (currentFlight.DepartureTime != departureInfo.DepartureTime)
                throw new ArgumentException("Date/time of departure does not correspond to the time specified in flight!");

            departureInfo.FlightId = currentFlight.Id;
            departureInfo.Flight = null;

            #endregion

            #region Проверка состояния самолета

            // проверяем состояние самолета
            if (departureInfo.Plane == null)
            {
                if (departureInfo.PlaneId.HasValue)
                {
                    currentPlane = AircraftService.GetPlaneInfoIncluded(departureInfo.PlaneId.Value);
                    if (currentPlane == null)
                        throw new ArgumentException($"Plane with id = {departureInfo.CrewId.Value} not found!");
                }
                else
                {
                    throw new ArgumentNullException("There is no flight crew been assigned!");
                }
            }
            else
            {
                if (( await AircraftService.GetPlaneInfoAsync(departureInfo.Plane.Id)) == null)
                    throw new ArgumentException($"Plane with id = {departureInfo.FlightId.Value} is not exist in db!You need to add this plane first!");

                currentPlane = departureInfo.Plane;
            }

            if (currentPlane.Type == null)
                throw new ArgumentException("Information about plane type not found!");

            // проверить срок службы самолета
            if (DateTime.Now - currentPlane.ReleaseDate >= currentPlane.Lifetime)
                throw new ArgumentException("The lifetime of plane has expired!");

            // проверить необходимость тех обслуживания
            var checksNeeded = AircraftService.GetPlaneTechCondition(currentPlane);
            if (checksNeeded != CheckNeeded.None)
            {
                // тех. обслуживание
                currentPlane = await AircraftService.CarryOutMaintenanceAsync(currentPlane, checksNeeded, ct);
            }

            departureInfo.PlaneId = currentPlane.Id;
            departureInfo.Plane = null;

            #endregion

            #region Проверка экипажа

            // проверяем экипаж
            if (departureInfo.Crew == null)
            {
                if (departureInfo.CrewId.HasValue)
                {
                    // проверить есть ли сформированая команда
                    currentCrew = CrewingService.GetIncludedCrewInfo(departureInfo.CrewId.Value, false);
                    if (currentCrew == null)
                        throw new ArgumentException($"Crew with id = {departureInfo.CrewId.Value} not found!");
                }
                else
                {
                    throw new ArgumentNullException("There is no flight crew been assigned!");
                }
            }
            else
            {
                currentCrew = departureInfo.Crew;
            }

            // проверяем экипаж
            if (currentCrew.Pilot == null)
                throw new ArgumentException("There is no pilot assigned to flight!");
            else if (currentCrew.Pilot.ExperienceYears < 2)
                throw new ArgumentException("Fly a passenger plane can only pilot with experience at least a two years!");
            if (currentCrew.Stewardesses == null || currentCrew.Stewardesses.Count < 2)
                throw new ArgumentException("There must be at least two stewardesses in the team!");

            departureInfo.CrewId = currentCrew.Id;
            departureInfo.Crew = null;

            #endregion

            GenerateTicketsToFlightAsync(currentFlight, currentPlane.Type.Capacity, ct);
            return await FlightOperationsService.UpdateDepartureInfoAsync(departureInfo.Id, departureInfo, ct);
        }


        public override Ticket AddTicket(Ticket ticket)
        {
#warning протестить!
            if (ticket.Flight == null && !ticket.FlightId.HasValue)
                throw new ArgumentException("Ticket shoult have information about flight");

            var flightId = ticket.Flight != null ? ticket.Flight.Id : ticket.FlightId.Value;
            var departure = FlightOperationsService
                .GetDeparturesByInclude(d => d.FlightId == flightId, false, d => d.Plane)
                .FirstOrDefault();
            if (departure == null)
                throw new ArgumentException("It's impossible to add a ticket to a flight that does not have sheduled departures!");
            if (departure.Plane == null)
                throw new ArgumentException("Error! There is not plane attached to departure!");

            var flight = FlightOperationsService.GetFlightIncludeTickets(flightId);
            if (departure.Plane.Type.Capacity <= flight.Tickets.Count)
                throw new ArgumentException("There is no more free places, you can not add ticket!");

            return FlightOperationsService.AddTicket(ticket);
        }

        public override async Task<Ticket> AddTicketAsync(Ticket ticket, CancellationToken ct = default(CancellationToken))
        {
#warning протестить!
            if (ticket.Flight == null && !ticket.FlightId.HasValue)
                throw new ArgumentException("Ticket shoult have information about flight");

            var flightId = ticket.Flight != null ? ticket.Flight.Id : ticket.FlightId.Value;
            var departure = FlightOperationsService
                .GetDeparturesByInclude(d => d.FlightId == flightId, false, d => d.Plane)
                .FirstOrDefault();
            if (departure == null)
                throw new ArgumentException("It's impossible to add a ticket to a flight that does not have sheduled departures!");
            if (departure.Plane == null)
                throw new ArgumentException("Error! There is not plane attached to departure!");

            var flight = FlightOperationsService.GetFlightIncludeTickets(flightId);
            if (departure.Plane.Type.Capacity <= flight.Tickets.Count)
                throw new ArgumentException("There is no more free places, you can not add ticket!");

            return await FlightOperationsService.AddTicketAsync(ticket, ct);
        }

        private void GenerateTicketsToFlight(Flight flight, int count)
        {
            var tickets = new List<Ticket>();
            int deltaPoint = count / 100 * 60;
            double currentPrice = ticketPriceBase;

            for (int i = 0; i < count; i++)
            {
                if (i == deltaPoint)
                    currentPrice = ticketPriceBase + ticketPriceDelta;
                tickets.Add(new Ticket()
                {
                    Price = currentPrice,
                    Seat = 1 + i
                });
            }

            flight.Tickets = tickets;
            FlightOperationsService.ModifyFlight(flight.Id, flight);
        }

        private async Task GenerateTicketsToFlightAsync(Flight flight, int count, CancellationToken ct)
        {
            
            var tickets = new List<Ticket>();
            int deltaPoint = count / 100 * 60;
            double currentPrice = ticketPriceBase;

            await Task.Run(() => 
            {
                for (int i = 0; i < count; i++)
                {
                    if (i == deltaPoint)
                        currentPrice = ticketPriceBase + ticketPriceDelta;
                    tickets.Add(new Ticket()
                    {
                        Price = currentPrice,
                        Seat = 1 + i
                    });
                }
            }, ct);

            flight.Tickets = tickets;
            await FlightOperationsService.ModifyFlightAsync(flight.Id, flight, ct);
        }

        #region Not implemented yet

        public override bool DeleteDeparture(long id)
        {
#warning необходимо так же удалить билеты
            return FlightOperationsService.TryCancelDeparture(id);
        }

        public override Flight ModifyFlight(long id, Flight flight)
        {
#warning проверить модифицируются ли билеты
            flight.Id = id;
            throw new NotImplementedException();
        }

        public override async Task<Flight> ModifyFlightAsync(long id, Flight flight, CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override async Task<Departure> ModifyDepartureAsync(long id, Departure departureInfo, CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override bool DeleteFlight(long id)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> DeleteFlightAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> DeleteDepartureAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override Departure ModifyDeparture(long id, Departure departureInfo)
        {
#warning изменить количество билетов
            departureInfo.Id = id;
            throw new NotImplementedException();
        }

        #endregion

    }
}
