using System;
using NUnit.Framework;
using ProjectStructure.WebApi.Controllers;
using ProjectStructure.Infrastructure.BL;
using mapper = ProjectStructure.Infrastructure.Shared.Mappings.AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Databases.MSSQL;
using ProjectStructure.Infrastructure.Data.Aircraft;

namespace ProjectStructure.Tests.IntegrationTests.FlightOperations
{
    [TestFixture]
    public class IntegrationFlightOpTest
    {
        //[Test]
        //public void AddDeleteDeparture_Returns_CreatedResult_And_PlaneType_ShoudBe_AddedTo_Database_And_Then_ShouldBe_Deleted()
        //{
        //    // Arrange
        //    MSSQLContext context = new MSSQLContext();
        //    PlaneTypesRepository planeTypesRepository = new PlaneTypesRepository();
        //    PlanesRepository planesRepository = new PlanesRepository();
        //    AircraftUnitOfWork uow = new AircraftUnitOfWork(planesRepository, planeTypesRepository, context);
        //    AircraftService service = new AircraftService(uow);
        //    PlaneTypesController controller = new PlaneTypesController(mapper.GetDefaultMapper(), service);

        //    // add act
        //    var newPlaneTypeDTO = new PlaneTypeDTO()
        //    {
        //        Capacity = 100,
        //        CargoCapacity = 5000,
        //        Model = "Hurricane"
        //    };

        //    var addResult = controller.AddPlaneType(newPlaneTypeDTO);

        //    // add assert
        //    Assert.IsInstanceOf<CreatedResult>(addResult);
        //    Assert.IsInstanceOf<PlaneTypeDTO>((addResult as CreatedResult).Value);

        //    // delete act
        //    var addedPlaneTypeDTO = (addResult as CreatedResult).Value as PlaneTypeDTO;
        //    var deleteResult = controller.DeletePlaneType(addedPlaneTypeDTO.Id);
        //    // delete assert
        //    Assert.IsInstanceOf<OkResult>(deleteResult);
        //    Assert.IsInstanceOf<NotFoundObjectResult>(controller.GetPlaneType(addedPlaneTypeDTO.Id));
        //}

    }
}
