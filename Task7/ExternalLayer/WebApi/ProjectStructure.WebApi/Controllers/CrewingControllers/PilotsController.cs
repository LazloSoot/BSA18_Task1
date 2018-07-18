using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Domain;
using ProjectStructure.Infrastructure.Shared;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.crewingRoute)]
    public class PilotsController : Controller
    {
        private readonly ICrewingService service;
        private readonly IMapper mapper;

        public PilotsController(IMapper mapper, ICrewingService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET: api/crews/pilots
        [HttpGet("pilots")]
        public async Task<IActionResult> GetAllPilots()
        {
            var pilots = await service.GetAllPilotsInfoAsync();
            return pilots == null ? NotFound("No pilots found!") as IActionResult
                : Ok(mapper.Map<IEnumerable<PilotDTO>>(pilots));
        }

        // GET: api/crews/pilots/:id
        [HttpGet("pilots/{id}", Name = "GetPilot")]
        public async Task<IActionResult> GetPilot(long id)
        {
            var pilot = await service.GetPilotInfoAsync(id);
            return pilot == null ? NotFound($"Pilot with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<PilotDTO>(pilot));
        }

        // POST: api/crews/pilots
        [HttpPost("pilots")]
        public async Task<IActionResult> AddPilot([FromBody]PilotDTO pilot)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = await service.HirePilotAsync(mapper.Map<Pilot>(pilot));
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<PilotDTO>(entity));
        }

        // PUT: api/crews/pilots/:id
        [HttpPut("pilots/{id}")]
        public async Task<IActionResult> ModifyPilot(long id, [FromBody]PilotDTO pilot)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = await service.UpdatePilotInfoAsync(id, mapper.Map<Pilot>(pilot));
            return entity == null ? StatusCode(304) as IActionResult
                : Ok(mapper.Map<PilotDTO>(entity));
        }

        // DELETE: api/crews/pilots/5
        [HttpDelete("pilots/{id}")]
        public async Task<IActionResult> DeletePilot(long id)
        {
            var success = await service.TryDismissPilotAsync(id);
            return success ? Ok() : StatusCode(304) as IActionResult;
        }
    }
}
