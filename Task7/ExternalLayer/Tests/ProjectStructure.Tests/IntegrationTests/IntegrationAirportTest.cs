using System;
using NUnit.Framework;
using ProjectStructure.WebApi.Controllers;
using ProjectStructure.Infrastructure.BL;
using mapper = ProjectStructure.Infrastructure.Shared.Mappings.AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Databases.MSSQL;
using ProjectStructure.Infrastructure.Data.Aircraft;
using ProjectStructure.Infrastructure.Data.Crewing;
using ProjectStructure.Infrastructure.Data.FlightOperations;
using ProjectStructure.Domain;
using System.Linq;
using Moq;
using ProjectStructure.Infrastructure.Data;

namespace ProjectStructure.Tests.IntegrationTests
{
    [TestFixture]
    public class IntegrationAirportTest
    {
        static long crewId;

        [SetUp]
        public void AddingCrew()
        {
            MSSQLContext context = new MSSQLContext();
            CrewsRepository crewsRepository = new CrewsRepository();
            PilotsRepository pRepository = new PilotsRepository();
            StewardessesRepository sRepository = new StewardessesRepository();
            CrewingUnitOfWork uow = new CrewingUnitOfWork(crewsRepository, pRepository, sRepository, context);
           
            var crew  = uow.Crews.Update(new Crew()
            {
                Pilot = pRepository.Get(1),
                Stewardesses = sRepository.GetAll().Take(3).ToList()
            });
            uow.SaveChanges();
            crewId = crew.Id;
        }

        [Test]
        public async void SheduleDeleteDeparture_When_All_Args_IsOk_When_Should_Return_CreatedResult_And_Add_Departure_To_dB_And_Then_Delete()
        {
            // Arrange

            #region ControllerInit

            MSSQLContext context = new MSSQLContext();
            PlaneTypesRepository planeTypesRepository = new PlaneTypesRepository();
            PlanesRepository planesRepository = new PlanesRepository();
            AircraftUnitOfWork uow = new AircraftUnitOfWork(planesRepository, planeTypesRepository, context);
            AircraftService service = new AircraftService(uow);

            CrewsRepository crewsRepository = new CrewsRepository();
            PilotsRepository pilotsRepository = new PilotsRepository();
            StewardessesRepository stewardessesRepository = new StewardessesRepository();
            CrewingUnitOfWork cuow = new CrewingUnitOfWork(crewsRepository, pilotsRepository, stewardessesRepository, context);
            CrewingService crewingService = new CrewingService(cuow, mapper.GetDefaultMapper());

            FlightsRepository flightRepository = new FlightsRepository();
            DeparturesRepository departuresRepository = new DeparturesRepository();
            TicketsRepository ticketsRepository = new TicketsRepository();
            FlightOperationsUnitOfWork flightOpUow = new FlightOperationsUnitOfWork(flightRepository, ticketsRepository, departuresRepository, context);
            FlightOperationsService flightOpeService = new FlightOperationsService(flightOpUow);

            AiroportService airportService = new AiroportService(service, crewingService, flightOpeService);
            AirportController controller = new AirportController(mapper.GetDefaultMapper(), airportService);

            #endregion

            var departureDto = new DepartureDTO()
            {
                CrewId = crewId,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                PlaneId = 2,
                FlightId = 1
            };

            var addResult = await controller.SheduleDeparture(departureDto);

            // add assert
            Assert.IsInstanceOf<CreatedResult>(addResult);
            Assert.IsInstanceOf<DepartureDTO>((addResult as CreatedResult).Value);

            // delete act
            var addedDepartureDTO = (addResult as CreatedResult).Value as DepartureDTO;
            var deleteResult = controller.DeleteDeparture(addedDepartureDTO.Id);
            // delete assert
            Assert.IsInstanceOf<OkResult>(deleteResult);

            Assert.IsNull(departuresRepository.Get(addedDepartureDTO.Id));
        }

        //[TearDown]
        //public void DeletingCrew()
        //{
        //    MSSQLContext context = new MSSQLContext();
        //    CrewsRepository crewsRepository = new CrewsRepository();
        //    PilotsRepository pRepository = new PilotsRepository();
        //    StewardessesRepository sRepository = new StewardessesRepository();
        //    CrewingUnitOfWork uow = new CrewingUnitOfWork(crewsRepository, pRepository, sRepository, context);

        //    uow.Crews.Delete(crewId);
        //    uow.SaveChanges();
        //}
    }
}
