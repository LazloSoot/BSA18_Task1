using System;
using NUnit.Framework;
using ProjectStructure.WebApi.Controllers;
using ProjectStructure.Infrastructure.BL;
using mapper = ProjectStructure.Infrastructure.Shared.Mappings.AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Databases.MSSQL;
using ProjectStructure.Infrastructure.Data.Aircraft;

namespace ProjectStructure.Tests.IntegrationTests.Aircraft
{
    [TestFixture]
    public class IntegrationAircraftTest
    {
       [Test]
       public void AddDeletePlaneType_Returns_CreatedResult_And_PlaneType_ShoudBe_AddedTo_Database_And_Then_ShouldBe_Deleted()
        {
            // Arrange
            MSSQLContext context = new MSSQLContext();
            PlaneTypesRepository planeTypesRepository = new PlaneTypesRepository();
            PlanesRepository planesRepository = new PlanesRepository();
            AircraftUnitOfWork uow = new AircraftUnitOfWork(planesRepository, planeTypesRepository, context);
            AircraftService service = new AircraftService(uow);
            PlaneTypesController controller = new PlaneTypesController(mapper.GetDefaultMapper(), service);

            // add act
            var newPlaneTypeDTO = new PlaneTypeDTO()
            {
                Capacity = 100,
                CargoCapacity = 5000,
                Model = "Hurricane"
            };

            var addResult = controller.AddPlaneType(newPlaneTypeDTO);

            // add assert
            Assert.IsInstanceOf<CreatedResult>(addResult);
            Assert.IsInstanceOf<PlaneTypeDTO>((addResult as CreatedResult).Value);

            // delete act
            var addedPlaneTypeDTO = (addResult as CreatedResult).Value as PlaneTypeDTO;
            var deleteResult = controller.DeletePlaneType(addedPlaneTypeDTO.Id);
            // delete assert
            Assert.IsInstanceOf<OkResult>(deleteResult);
            Assert.IsInstanceOf<NotFoundObjectResult>(controller.GetPlaneType(addedPlaneTypeDTO.Id));
        }

        [Test]
        public void AddDeletePlane_Returns_CreatedResult_And_Plane_ShoudBe_AddedTo_Database_And_Then_ShouldBe_Deleted()
        {
            // Arrange
            MSSQLContext context = new MSSQLContext();
            PlaneTypesRepository planeTypesRepository = new PlaneTypesRepository();
            PlanesRepository planesRepository = new PlanesRepository();
            AircraftUnitOfWork uow = new AircraftUnitOfWork(planesRepository, planeTypesRepository, context);
            AircraftService service = new AircraftService(uow);
            PlanesController controller = new PlanesController(mapper.GetDefaultMapper(), service);

            // add act
            var newPlaneDTO = new PlaneDTO()
            {
                Lifetime = new TimeSpan(200, 0, 0, 0, 0),
                Name = "Bf-109g",
                ReleaseDate = new DateTime(1941, 1, 1, 0, 0, 0),
                FlightHours = 560,
                LastHeavyMaintenance = DateTime.Now,
                PlaneTypeId = 1
            };

            var addResult = controller.AddPlane(newPlaneDTO);

            // add assert
            Assert.IsInstanceOf<CreatedResult>(addResult);
            Assert.IsInstanceOf<PlaneDTO>((addResult as CreatedResult).Value);

            // delete act
            var addedPlaneDTO = (addResult as CreatedResult).Value as PlaneDTO;
            var deleteResult = controller.DeletePlane(addedPlaneDTO.Id);
            // delete assert
            Assert.IsInstanceOf<OkResult>(deleteResult);
            Assert.IsInstanceOf<NotFoundObjectResult>(controller.GetPlane(addedPlaneDTO.Id));
        }
    }
}
