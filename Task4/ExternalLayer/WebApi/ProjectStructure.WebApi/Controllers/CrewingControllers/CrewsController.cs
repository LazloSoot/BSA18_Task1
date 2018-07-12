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
            var crews = service.GetAllCrews();
            return crews == null ? NotFound("No pilots found!") as IActionResult : Ok(crews);
        }

        // GET: api/crews/:id
        [HttpGet("{id}", Name = "GetCrew")]
        public IActionResult GetCrew(int id)
        {
            var pilot = service.GetCrew(id);
            return pilot == null ? NotFound($"Pilot with id = {id} not found!") as IActionResult : Ok(pilot);
        }
        
        // POST: api/crews
        [HttpPost]
        public IActionResult AddCrew([FromBody]Crew crew)
        {
            var entity = service.AddCrew(crew);
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }
        
        // PUT: api/crews/:id
        [HttpPut("{id}")]
        public IActionResult ModifyCrew(int id, [FromBody]Crew crew)
        {
            var entity = service.ModifyCrew(crew);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
        }
        
        // DELETE: api/crews/:id
        [HttpDelete("{id}")]
        public IActionResult DeleteCrew(int id)
        {
            var entity = service.DeleteCrew(id);
            return entity == null ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
