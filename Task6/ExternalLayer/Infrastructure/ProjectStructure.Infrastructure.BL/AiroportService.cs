using System;
using System.Collections.Generic;
using System.Text;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.Domain.Interfaces;

namespace ProjectStructure.Infrastructure.BL
{
    public class AiroportService : Airport
    {
        public AiroportService(IAircraftService aircraftService, ICrewingService crewingService,
           IFlightOperationsService flightOperationsService)
            :base(aircraftService, crewingService, flightOperationsService)
        {
        }

        public override Ticket AddTicket(Ticket ticket)
        {
            throw new NotImplementedException();
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
                    currentPlane = AircraftService.GetPlaneInfo(departureInfo.PlaneId.Value);
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

            return FlightOperationsService.UpdateDepartureInfo(departureInfo);
        }

        public override bool DeleteDeparture(long id)
        {
            return FlightOperationsService.TryCancelDeparture(id);
        }

        public override Flight ModifyFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteFlight(long id)
        {
            throw new NotImplementedException();
        }

        public override Departure ModifyDeparture(Departure departureInfo)
        {
            throw new NotImplementedException();
        }

        
    }
}
