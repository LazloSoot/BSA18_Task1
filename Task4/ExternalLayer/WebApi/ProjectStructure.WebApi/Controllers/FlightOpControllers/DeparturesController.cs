using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.flightOperations)]
    public class DeparturesController : Controller
    {
        private readonly IFlightOperationsService service;

        public DeparturesController(IFlightOperationsService service)
        {
            this.service = service;
        }

        // GET: api/flights/departures
        [HttpGet("departures")]
        public IActionResult GetAllDepartures()
        {
            var departures = service.GetAllDepartures();
            return departures == null ? NotFound("No departures found!") as IActionResult : Ok(departures);
        }

        // GET: api/flights/departures/:id
        [HttpGet("{id}", Name = "GetDeparture")]
        public IActionResult GetDeparture(int id)
        {
            var departure = service.GetDeparture(id);
            return departure == null ? NotFound($"Departure with id = {id} not found!") as IActionResult : Ok(departure);
        }

        // POST: api/flights/departures
        [HttpPost("departures")]
        public IActionResult AddDeparture([FromBody]Departure departure)
        {
            var entity = service.AddDeparture(departure);
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }

        // PUT: api/flights/:id
        [HttpPut("{id}")]
        public void ModifyDeparture(int id, [FromBody]Departure departure)
        {
            var entity = service.ModifyDeparture(departure);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
        }

        // DELETE: api/flights
        [HttpDelete("{id}")]
        public IActionResult DeleteDeparture(int id)
        {
            var entity = service.DeleteDeparture(id);
            return entity == null ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
