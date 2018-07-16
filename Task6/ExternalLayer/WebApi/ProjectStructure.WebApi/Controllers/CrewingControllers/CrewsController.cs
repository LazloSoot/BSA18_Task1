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
    public class CrewsController : Controller
    {
        private readonly ICrewingService service;
        private readonly IMapper mapper;

        public CrewsController(IMapper mapper, ICrewingService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET: api/crews
        [HttpGet]
        public IActionResult GetAllCrews()
        {
            var crews = service.GetAllCrewsInfo();
            return crews == null ? NotFound("No crews found!") as IActionResult
                : Ok(mapper.Map<IEnumerable<CrewDTO>>(crews));
        }

        // GET: api/crews/:id
        [HttpGet("{id}", Name = "GetCrew")]
        public IActionResult GetCrew(long id)
        {
            var crew = service.GetCrewInfo(id);
            return crew == null ? NotFound($"Crew with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<CrewDTO>(crew));
        }
        
        // POST: api/crews
        [HttpPost]
        public IActionResult CreateCrew([FromBody]long pilotId, [FromBody]IEnumerable<long> stewardressesIds)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.CreateCrew(pilotId, stewardressesIds);
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}",
                mapper.Map<CrewDTO>(entity));
        }
        
        // PUT: api/crews/:id
        [HttpPut("{id}")]
        public IActionResult ModifyCrew([FromBody]long crewId, 
            [FromBody]long pilotId, [FromBody]IEnumerable<long> stewardressesIds)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.ReformCrew(crewId, pilotId, stewardressesIds);
            return entity == null ? StatusCode(304) as IActionResult
                : Ok(mapper.Map<CrewDTO>(entity));
        }
        
        // DELETE: api/crews/:id
        [HttpDelete("{id}")]
        public IActionResult DeleteCrew(int id)
        {
            var entity = service.TryDeleteCrew(id);
            return entity ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
