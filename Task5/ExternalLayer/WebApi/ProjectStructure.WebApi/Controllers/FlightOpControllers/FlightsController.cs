﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.flightOperations)]
    public class FlightsController : Controller
    {
        private readonly IFlightOperationsService service;

        public FlightsController(IFlightOperationsService service)
        {
            this.service = service;
        }

        // GET: api/flights
        [HttpGet]
        public IActionResult GetAllFlights()
        {
            var flights = service.GetAllFlightsInfo();
            return flights == null ? NotFound("No departures found!") as IActionResult : Ok(flights);
        }

        // GET: api/flights/:id
        [HttpGet("{id}", Name = "GetFlight")]
        public IActionResult GetFlight(int id)
        {
            var flight = service.GetFlightInfo(id);
            return flight == null ? NotFound($"Flight with id = {id} not found!") as IActionResult : Ok(flight);
        }

        // POST: api/flights
        [HttpPost]
        public IActionResult AddFlight([FromBody]Flight flight)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.AddFlight(flight);
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }

        // PUT: api/flights/:id
        [HttpPut("{id}")]
        public IActionResult ModifyFlight(int id, [FromBody]Flight flight)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.ModifyFlight(flight);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
        }

        // DELETE: api/flights/:id
        [HttpDelete("{id}")]
        public IActionResult DeleteFlight(int id)
        {
            var entity = service.TryCancelFlight(id);
            return entity ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
