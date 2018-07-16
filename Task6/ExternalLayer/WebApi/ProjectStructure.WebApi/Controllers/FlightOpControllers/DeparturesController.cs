using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.Infrastructure.Shared;
using AutoMapper;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.flightOperations)]
    public class DeparturesController : Controller
    {
        private readonly IFlightOperationsService service;
        private readonly IMapper mapper;

        public DeparturesController(IMapper mapper, IFlightOperationsService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET: api/flights/departures
        [HttpGet("departures")]
        public IActionResult GetAllDepartures()
        {
            var departures = service.GetAllDeparturesInfo();
            return departures == null ? NotFound("No departures found!") as IActionResult
                : Ok(mapper.Map<IEnumerable<DepartureDTO>>(departures));
        }

        // GET: api/flights/departures/:id
        [HttpGet("departures/{id}", Name = "GetDeparture")]
        public IActionResult GetDeparture(int id)
        {
            var departure = service.GetDepartureInfo(id);
            return departure == null ? NotFound($"Departure with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<DepartureDTO>(departure));
        }

        // GET: api/flights/:id/departures
        [HttpGet("{id}/departures", Name = "GetFlightDepartures")]
        public IActionResult GetFlightDepartures(int id)
        {
            var departures = service.GetFlightDepartureInfo(id);
            return departures == null ? NotFound($"Flight with id = {id} have not departure yet!") as IActionResult
                : Ok(mapper.Map<IEnumerable<DepartureDTO>>(departures));
        }

        // POST: api/flights/departures
        [HttpPost("departures")]
        public IActionResult AddDeparture([FromBody]DepartureDTO departure)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.SheduleDeparture(mapper.Map<Departure>(departure));
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}",
                mapper.Map<DepartureDTO>(entity));
        }

        // PUT: api/flights/departures/:id
        [HttpPut("departures/{id}")]
        public IActionResult ModifyDeparture([FromBody]DepartureDTO departure)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.UpdateDepartureInfo(mapper.Map<Departure>(departure));
            return entity == null ? StatusCode(304) as IActionResult
                : Ok(mapper.Map<DepartureDTO>(entity));
        }

        // DELETE: api/flights/departures/:id
        [HttpDelete("departures/{id}")]
        public IActionResult DeleteDeparture(int id)
        {
            var entity = service.TryCancelDeparture(id);
            return entity ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
