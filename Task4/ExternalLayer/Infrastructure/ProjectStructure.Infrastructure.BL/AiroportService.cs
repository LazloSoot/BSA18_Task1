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
        public override IEnumerable<Ticket> CreateFlight(Flight flightInfo, Departure departureInfo)
        {
            // проверить состав экипажа, опыт пилота
            // проверить состояния самолета/ отправить на тех. осмотр
            // проверить даты
            throw new NotImplementedException();
        }

        public override IEnumerable<Ticket> CreateFlight(long flightId, long departureId)
        {
            throw new NotImplementedException();
        }
    }
}
