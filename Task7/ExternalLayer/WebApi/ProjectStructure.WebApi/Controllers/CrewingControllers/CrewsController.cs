using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using System;
using Newtonsoft.Json.Converters;
using System.Net;
using System.Threading.Tasks;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.crewingRoute)]
    public class CrewsController : Controller
    {
        private readonly ICrewingService service;
        private readonly IMapper mapper;
        private readonly string outsourceCrewsUri;

        public CrewsController(IMapper mapper, ICrewingService service)
        {
            this.mapper = mapper;
            this.service = service;
            outsourceCrewsUri = @"http://5b128555d50a5c0014ef1204.mockapi.io/crew";
        }

        // GET: api/crews
        [HttpGet]
        public async Task<IActionResult> GetAllCrews()
        {
            var crews = await service.GetAllCrewsInfoAsync();
            return crews == null ? NotFound("No crews found!") as IActionResult
                : Ok(mapper.Map<IEnumerable<CrewDTO>>(crews));
        }

        // GET: api/crews/outsource/load/:count
        [HttpGet("outsource/load/{count}")]
        public async Task<IActionResult> LoadOutsourceCrews(int count = -1)
        {
            try
            {
                await service.LoadOutSourceCrewsAsync(outsourceCrewsUri, count, new System.Threading.CancellationToken());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }

        

        // GET: api/crews/:id
        [HttpGet("{id}", Name = "GetCrew")]
        public async Task<IActionResult> GetCrew(long id)
        {
            var crew = await service.GetCrewInfoAsync(id);
            return crew == null ? NotFound($"Crew with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<CrewDTO>(crew));
        }
        
        // POST: api/crews
        [HttpPost]
        public async Task<IActionResult> CreateCrew([FromBody]long pilotId, [FromBody]IEnumerable<long> stewardressesIds)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = await service.CreateCrewAsync(pilotId, stewardressesIds);
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<CrewDTO>(entity));
        }
        
        // PUT: api/crews/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyCrew([FromBody]long crewId, 
            [FromBody]long pilotId, [FromBody]IEnumerable<long> stewardressesIds)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = await service.ReformCrewAsync(crewId, pilotId, stewardressesIds);
            return entity == null ? StatusCode(304) as IActionResult
                : Ok(mapper.Map<CrewDTO>(entity));
        }
        
        // DELETE: api/crews/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrew(long id)
        {
            var success = await service.TryDeleteCrewAsync(id);
            return success ? Ok() : StatusCode(304) as IActionResult;
        }
    }
}
