using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using ProjectStructure.Services.Interfaces;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using ProjectStructure.Domain;

namespace ProjectStructure.Tests.Controllers.FlightOperations
{
    //[TestFixture]
    //public class TicketsControllerTest
    //{
    //    [Test]
    //    public void GetAllTicketsTest()
    //    {
    //        // Arrange
    //        var serviceMock = new Mock<IFlightOperationsService>();
    //        serviceMock.SetReturnsDefault<object>(null);

    //        var mapperMock = new Mock<IMapper>();
    //        mapperMock.Setup(m => m.Map<TicketDTO, Ticket>(It.IsAny<TicketDTO>())).Returns(new Ticket());

    //        var service = new AircraftService(serviceMock.Object);
    //        var tickets = service.GetAllTicketsInfo();
    //        return tickets == null ? NotFound("No tickets found!") as IActionResult
    //            : Ok(mapper.Map<IEnumerable<TicketDTO>>(tickets));
    //    }

    //    [Test]
    //    public void GetFlightTickets(int id)
    //    {
    //        var tickets = service.GetFlightTicketsInfo(id);
    //        return tickets == null ? NotFound($"No tickets for flight with id = {id} found!") as IActionResult
    //            : Ok(mapper.Map<IEnumerable<TicketDTO>>(tickets));
    //    }

    //    [Test]
    //    public void GetTicket(int id)
    //    {
    //        var ticket = service.GetTicketInfo(id);
    //        return ticket == null ? NotFound($"Ticket with id = {id} not found!") as IActionResult
    //            : Ok(mapper.Map<TicketDTO>(ticket));
    //    }

    //    [Test]
    //    public void AddTicket([FromBody]TicketDTO ticket)
    //    {
    //        if (!ModelState.IsValid)
    //            return BadRequest() as IActionResult;

    //        var entity = service.AddTicket(mapper.Map<Ticket>(ticket));
    //        return entity == null ? StatusCode(409) as IActionResult
    //            : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}",
    //            mapper.Map<TicketDTO>(entity));
    //    }

    //    [Test]
    //    public void ModifyTicket([FromBody]TicketDTO ticket)
    //    {
    //        if (!ModelState.IsValid)
    //            return BadRequest() as IActionResult;

    //        var entity = service.ModifyTicket(mapper.Map<Ticket>(ticket));
    //        return entity == null ? StatusCode(304) as IActionResult
    //            : Ok(mapper.Map<Ticket>(entity));
    //    }

    //    [Test]
    //    public void DeleteTicket(int id)
    //    {
    //        var entity = service.TryDeleteTicket(id);
    //        return entity ? StatusCode(304) as IActionResult : Ok();
    //    }
    //}
}
