using System;
using System.Collections.Generic;
using NUnit.Framework;
using ProjectStructure.WebApi.Controllers;
using ProjectStructure.Infrastructure.BL;
using ProjectStructure.Infrastructure.Data.Crewing;
using mapper = ProjectStructure.Infrastructure.Shared.Mappings.AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Databases.MSSQL;

namespace ProjectStructure.Tests.IntegrationTests.Crewing
{
    [TestFixture]
    public class IntegrationCrewingTest
    {
        [Test]
        public async void AddDeleteNewPilotTest_Returns_CreatedResult_And_Pilot_ShoudBe_AddedTo_Database_And_Then_ShouldBe_Deleted()
        {
            // Arrange
            MSSQLContext context = new MSSQLContext();
            CrewsRepository crewsRepository = new CrewsRepository();
            PilotsRepository pilotsRepository = new PilotsRepository();
            StewardessesRepository stewardessesRepository = new StewardessesRepository();
            CrewingUnitOfWork uow = new CrewingUnitOfWork(crewsRepository, pilotsRepository, stewardessesRepository, context);
            CrewingService service = new CrewingService(uow, mapper.GetDefaultMapper());
            PilotsController controller = new PilotsController(mapper.GetDefaultMapper(), service);

            // add act
            var newPilotDTO = new PilotDTO()
            {
                Birth = new DateTime(1985, 5, 12, 0, 0, 0),
                ExperienceYears = 15,
                Name = "Grisha",
                Surname = "Kramer"
            };

            var addResult = await controller.AddPilot(newPilotDTO);

            // add assert
            Assert.IsInstanceOf<CreatedResult>(addResult);
            Assert.IsInstanceOf<PilotDTO>((addResult as CreatedResult).Value);

            // delete act
            var addedPilotDTO = (addResult as CreatedResult).Value as PilotDTO;
            var deleteResult = controller.DeletePilot(addedPilotDTO.Id);
            // delete assert
            Assert.IsInstanceOf<OkResult>(deleteResult);
            Assert.IsInstanceOf<NotFoundObjectResult>(controller.GetPilot(addedPilotDTO.Id));
        }

        [Test]
        public async void AddDeleteNewStewardessTest_Returns_CreatedResult_And_Stewardess_ShoudBe_AddedTo_Database_And_Then_ShouldBe_Deleted()
        {
            // Arrange
            MSSQLContext context = new MSSQLContext();
            CrewsRepository crewsRepository = new CrewsRepository();
            PilotsRepository pilotsRepository = new PilotsRepository();
            StewardessesRepository stewardessesRepository = new StewardessesRepository();
            CrewingUnitOfWork uow = new CrewingUnitOfWork(crewsRepository, pilotsRepository, stewardessesRepository, context);
            CrewingService service = new CrewingService(uow, mapper.GetDefaultMapper());
            StewardessesController controller = new StewardessesController(mapper.GetDefaultMapper(), service);

            // add act
            var newStewardessDTO = new StewardessDTO()
            {
                Birth = new DateTime(1985, 5, 12, 0, 0, 0),
                Name = "Masha",
                Surname = "Ivanova"
            };

            var addResult = await controller.AddStewardess(newStewardessDTO);

            // add assert
            Assert.IsInstanceOf<CreatedResult>(addResult);
            Assert.IsInstanceOf<StewardessDTO>((addResult as CreatedResult).Value);

            // delete act
            var addedStewardessDTO = (addResult as CreatedResult).Value as StewardessDTO;
            var deleteResult = controller.DeleteStewardess(addedStewardessDTO.Id);
            // delete assert
            Assert.IsInstanceOf<OkResult>(deleteResult);
            Assert.IsInstanceOf<NotFoundObjectResult>(controller.GetStewardess(addedStewardessDTO.Id));
        }

        [Test]
        public async void CreatingDeleteCrew_When_Pilot_And_Stewardess_Exist_In_Db_Then_Successfuly_And_Returns_Created_Crew_And_Then_ShouldBe_Deleted()
        {
            // Arrange
            MSSQLContext context = new MSSQLContext();
            CrewsRepository crewsRepository = new CrewsRepository();
            PilotsRepository pilotsRepository = new PilotsRepository();
            StewardessesRepository stewardessesRepository = new StewardessesRepository();
            CrewingUnitOfWork uow = new CrewingUnitOfWork(crewsRepository, pilotsRepository, stewardessesRepository, context);
            CrewingService service = new CrewingService(uow, mapper.GetDefaultMapper());
            CrewsController controller = new CrewsController(mapper.GetDefaultMapper(), service);
            
            // act (pilots and stewardesses from db seed)
            var createCrewResult = await controller.CreateCrew(1, new List<long> { 1, 2, 3, 4});
            
            // add assert
            Assert.IsInstanceOf<CreatedResult>(createCrewResult);
            Assert.IsInstanceOf<CrewDTO>((createCrewResult as CreatedResult).Value);

            // delete act
            var createdCrewDTO = (createCrewResult as CreatedResult).Value as CrewDTO;
            var deleteResult = controller.DeleteCrew(createdCrewDTO.Id);
            // delete assert
            Assert.IsInstanceOf<OkResult>(deleteResult);
            Assert.IsInstanceOf<NotFoundObjectResult>(controller.GetCrew(createdCrewDTO.Id));
        }
    }
}
