﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.crewingRoute)]
    public class StewardessesController : Controller
    {
        private readonly ICrewingService service;

        public StewardessesController(ICrewingService service)
        {
            this.service = service;
        }
        // GET: api/crews/stewardesses
        [HttpGet("stewardesses")]
        public IActionResult GetAllStewardesses()
        {
            var stewardesses = service.GetAllStewardessesInfo();
            return stewardesses == null ? NotFound("No stewardesses found!") as IActionResult : Ok(stewardesses);
        }

        // GET: api/crews/stewardesses/:id
        [HttpGet("stewardesses/{id}", Name = "GetStewardess")]
        public IActionResult GetStewardess(int id)
        {
            var stewardess = service.GetStewardessInfo(id);
            return stewardess == null ? NotFound($"Stewardess with id = {id} not found!") as IActionResult : Ok(stewardess);
        }

        // POST: api/crews/stewardesses
        [HttpPost("stewardesses")]
        public IActionResult AddStewardess([FromBody]Stewardess stewardess)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.HireStewardess(stewardess);
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }

        // PUT: api/crews/stewardesses/:id
        [HttpPut("stewardesses/{id}")]
        public IActionResult ModifyStewardess(int id, [FromBody]Stewardess stewardess)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.UpdateStewardessInfo(stewardess);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
        }

        // DELETE: api/crews/stewardesses/:id
        [HttpDelete("stewardesses/{id}")]
        public IActionResult DeleteStewardess(int id)
        {
            var successfuly = service.TryDismissStewardess(id);
            return successfuly ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
