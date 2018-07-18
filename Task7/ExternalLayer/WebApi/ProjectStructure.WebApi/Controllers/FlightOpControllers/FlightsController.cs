using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await service.GetAllFlightsInfoAsync();
            return flights == null ? NotFound("No departures found!") as IActionResult
                : Ok(mapper.Map<IEnumerable<FlightDTO>>(flights));
        }

        // GET: api/flights/task3
        [HttpGet]
        public async Task<IActionResult> GetAllFlightsTask()
        {
            var flights = await service.GetAllFlightsInfoAsync();
            return flights == null ? NotFound("No departures found!") as IActionResult
                : Ok(mapper.Map<IEnumerable<FlightDTO>>(flights));
        }

        // GET: api/flights/:id
        [HttpGet("{id}", Name = "GetFlight")]
        public async Task<IActionResult> GetFlight(long id)
        {
            var flight = await service.GetFlightInfoAsync(id);
            return flight == null ? NotFound($"Flight with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<FlightDTO>(flight));
        }

        // POST: api/flights
        [HttpPost]
        public async Task<IActionResult> AddFlight([FromBody]Flight flight)
        {
#warning перенести в AIRPORT
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = await service.AddFlightAsync(flight);
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<FlightDTO>(entity));
        }

#warning перенести в AIRPORT
        // PUT: api/flights/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyFlight(long id, [FromBody]FlightDTO flight)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = await service.ModifyFlightAsync(id, mapper.Map<Flight>(flight));
            return entity == null ? StatusCode(304) as IActionResult 
                : Ok(mapper.Map<FlightDTO>(entity));
        }

        // DELETE: api/flights/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(long id)
        {
            var entity = await service.TryCancelFlightAsync(id);
            return entity ? Ok() : StatusCode(304) as IActionResult ;
        }
    }
}
