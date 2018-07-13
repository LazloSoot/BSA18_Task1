using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.crewingRoute)]
    public class CrewsController : Controller
    {
        private readonly ICrewingService service;

        public CrewsController(ICrewingService service)
        {
            this.service = service;
        }

        // GET: api/crews
        [HttpGet]
        public IActionResult GetAllCrews()
        {
            var crews = service.GetAllCrewsInfo();
            return crews == null ? NotFound("No crews found!") as IActionResult : Ok(crews);
        }

        // GET: api/crews/:id
        [HttpGet("{id}", Name = "GetCrew")]
        public IActionResult GetCrew(long id)
        {
            var crew = service.GetCrewInfo(id);
            return crew == null ? NotFound($"Crew with id = {id} not found!") as IActionResult : Ok(crew);
        }
        
        // POST: api/crews
        [HttpPost]
        public IActionResult AddCrew([FromBody]Crew crew)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.AddCrew(crew);
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }
        
        // PUT: api/crews/:id
        [HttpPut("{id}")]
        public IActionResult ModifyCrew(int id, [FromBody]Crew crew)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.ReformCrew(crew);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
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
