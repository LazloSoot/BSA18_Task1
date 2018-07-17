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
    [Route(RouteConstants.crewingRoute)]
    public class StewardessesController : Controller
    {
        private readonly ICrewingService service;
        private readonly IMapper mapper;

        public StewardessesController(IMapper mapper, ICrewingService service)
        {
            this.mapper = mapper;
            this.service = service;
        }
        // GET: api/crews/stewardesses
        [HttpGet("stewardesses")]
        public IActionResult GetAllStewardesses()
        {
            var stewardesses = service.GetAllStewardessesInfo();
            return stewardesses == null ? NotFound("No stewardesses found!") as IActionResult
                : Ok(mapper.Map<IEnumerable<StewardessDTO>>(stewardesses));
        }

        // GET: api/crews/stewardesses/:id
        [HttpGet("stewardesses/{id}", Name = "GetStewardess")]
        public IActionResult GetStewardess(long id)
        {
            var stewardess = service.GetStewardessInfo(id);
            return stewardess == null ? NotFound($"Stewardess with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<StewardessDTO>(stewardess));
        }

        // POST: api/crews/stewardesses
        [HttpPost("stewardesses")]
        public IActionResult AddStewardess([FromBody]StewardessDTO stewardess)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.HireStewardess(mapper.Map<Stewardess>(stewardess));
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<StewardessDTO>(entity));
        }

        // PUT: api/crews/stewardesses/:id
        [HttpPut("stewardesses/{id}")]
        public IActionResult ModifyStewardess([FromBody]StewardessDTO stewardess)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.UpdateStewardessInfo(mapper.Map<Stewardess>(stewardess));
            return entity == null ? StatusCode(304) as IActionResult
                : Ok(mapper.Map<StewardessDTO>(entity));
        }

        // DELETE: api/crews/stewardesses/:id
        [HttpDelete("stewardesses/{id}")]
        public IActionResult DeleteStewardess(long id)
        {
            var successfuly = service.TryDismissStewardess(id);
            return successfuly ? Ok() : StatusCode(304) as IActionResult;
        }
    }
}
