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
    public class FlightsController : Controller
    {
        private readonly IFlightOperationsService service;
        private readonly IMapper mapper;

        public FlightsController(IMapper mapper, IFlightOperationsService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET: api/flights
        [HttpGet]
        public IActionResult GetAllFlights()
        {
            var flights = service.GetAllFlightsInfo();
            return flights == null ? NotFound("No departures found!") as IActionResult
                : Ok(mapper.Map<IEnumerable<FlightDTO>>(flights));
        }

        // GET: api/flights/:id
        [HttpGet("{id}", Name = "GetFlight")]
        public IActionResult GetFlight(long id)
        {
            var flight = service.GetFlightInfo(id);
            return flight == null ? NotFound($"Flight with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<FlightDTO>(flight));
        }

        // POST: api/flights
        [HttpPost]
        public IActionResult AddFlight([FromBody]Flight flight)
        {
#warning перенести в AIRPORT
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.AddFlight(flight);
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<FlightDTO>(entity));
        }

#warning перенести в AIRPORT
        // PUT: api/flights/:id
        [HttpPut("{id}")]
        public IActionResult ModifyFlight([FromBody]FlightDTO flight)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.ModifyFlight(mapper.Map<Flight>(flight));
            return entity == null ? StatusCode(304) as IActionResult 
                : Ok(mapper.Map<FlightDTO>(entity));
        }

        // DELETE: api/flights/:id
        [HttpDelete("{id}")]
        public IActionResult DeleteFlight(long id)
        {
            var entity = service.TryCancelFlight(id);
            return entity ? Ok() : StatusCode(304) as IActionResult ;
        }
    }
}
