using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.flightOperations)]
    public class TicketsController : Controller
    {
        private readonly IFlightOperationsService service;
        private readonly IMapper mapper;

        public TicketsController(IMapper mapper, IFlightOperationsService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET: api/flights/tickets
        [HttpGet("tickets")]
        public IActionResult GetAllTickets()
        {
            var tickets = service.GetAllTicketsInfo();
            return tickets == null ? NotFound("No tickets found!") as IActionResult
                : Ok(mapper.Map<IEnumerable<TicketDTO>>(tickets));
        }

        // GET: api/flights/:id/tickets
        [HttpGet(RouteConstants.getById + "/tickets", Name ="GetFlightTickets")]
        public IActionResult GetFlightTickets(int id)
        {
            var tickets = service.GetFlightTicketsInfo(id);
            return tickets == null ? NotFound($"No tickets for flight with id = {id} found!") as IActionResult
                : Ok(mapper.Map<IEnumerable<TicketDTO>>(tickets));
        }

        // GET: api/flights/tickets/:id
        [HttpGet("tickets/{id}", Name = "GetTicket")]
        public IActionResult GetTicket(int id)
        {
            var ticket = service.GetTicketInfo(id);
            return ticket == null ? NotFound($"Ticket with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<TicketDTO>(ticket));
        }

        // POST: api/flights/tickets
        [HttpPost("tickets")]
        public IActionResult AddTicket([FromBody]TicketDTO ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = service.AddTicket(mapper.Map<Ticket>(ticket));
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}",
                mapper.Map<TicketDTO>(entity));
        }

        // PUT: api/flights/tickets/:id
        [HttpPut("tickets/{id}")]
        public IActionResult ModifyTicket([FromBody]TicketDTO ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = service.ModifyTicket(mapper.Map<Ticket>(ticket));
            return entity == null ? StatusCode(304) as IActionResult
                : Ok(mapper.Map<Ticket>(entity));
        }

        // DELETE: api/flights/tickets/:id
        [HttpDelete("tickets/{id}")]
        public IActionResult DeleteTicket(int id)
        {
            var entity = service.TryDeleteTicket(id);
            return entity ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
