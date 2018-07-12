using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.flightOperations)]
    public class TicketsController : Controller
    {
        private readonly IFlightOperationsService service;

        public TicketsController(IFlightOperationsService service)
        {
            this.service = service;
        }

        // GET: api/flights/tickets
        [HttpGet("tickets")]
        public IActionResult GetAllTickets()
        {
            var tickets = service.GetAllTickets();
            return tickets == null ? NotFound("No tickets found!") as IActionResult : Ok(tickets);
        }

        // GET: api/flights/:id/tickets
        [HttpGet(RouteConstants.getById + "/tickets", Name ="GetFlightTickets")]
        public IActionResult GetFlightTickets(int id)
        {
            var tickets = service.GetFlightTickets(id);
            return tickets == null ? NotFound($"No tickets for flight with id = {id} found!") as IActionResult : Ok(tickets);
        }

        // GET: api/flights/tickets/:id
        [HttpGet("tickets/{id}", Name = "GetTicket")]
        public IActionResult GetTicket(int id)
        {
            var ticket = service.GetTicket(id);
            return ticket == null ? NotFound($"Ticket with id = {id} not found!") as IActionResult : Ok(ticket);
        }

        // POST: api/flights/tickets
        [HttpPost("tickets")]
        public IActionResult AddTicket([FromBody]Ticket ticket)
        {
            var entity = service.AddTicket(ticket);
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }

        // PUT: api/flights/tickets/:id
        [HttpPut("tickets/{id}")]
        public void ModifyTicket(int id, [FromBody]Ticket ticket)
        {
            var entity = service.ModifyTicket(ticket);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
        }

        // DELETE: api/flights/tickets/:id
        [HttpDelete("tickets/{id}")]
        public IActionResult DeleteTicket(int id)
        {
            var entity = service.DeleteTicket(id);
            return entity == null ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
