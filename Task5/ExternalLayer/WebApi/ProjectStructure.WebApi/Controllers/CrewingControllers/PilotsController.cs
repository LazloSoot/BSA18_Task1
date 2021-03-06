﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.crewingRoute)]
    public class PilotsController : Controller
    {
        private readonly ICrewingService service;

        public PilotsController(ICrewingService service)
        {
            this.service = service;
        }

        // GET: api/crews/pilots
        [HttpGet("pilots")]
        public IActionResult GetAllPilots()
        {
            var pilots = service.GetAllPilotsInfo();
            return pilots == null ? NotFound("No pilots found!") as IActionResult : Ok(pilots);
        }

        // GET: api/crews/pilots/:id
        [HttpGet("pilots/{id}", Name = "GetPilot")]
        public IActionResult GetPilot(int id)
        {
            var pilot = service.GetPilotInfo(id);
            return pilot == null ? NotFound($"Pilot with id = {id} not found!") as IActionResult : Ok(pilot);
        }

        // POST: api/crews/pilots
        [HttpPost("pilots")]
        public IActionResult AddPilot([FromBody]Pilot pilot)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.HirePilot(pilot);
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }

        // PUT: api/crews/pilots/:id
        [HttpPut("pilots/{id}")]
        public IActionResult ModifyPilot(int id, [FromBody]Pilot pilot)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.UpdatePilotInfo(pilot);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
        }

        // DELETE: api/crews/pilots/5
        [HttpDelete("pilots/{id}")]
        public IActionResult DeletePilot(int id)
        {
            var entity = service.TryDismissPilot(id);
            return entity ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
