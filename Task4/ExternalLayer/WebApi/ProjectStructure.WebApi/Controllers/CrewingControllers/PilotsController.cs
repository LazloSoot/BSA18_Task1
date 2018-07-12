using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.crewingRoute + "/pilots")]
    public class PilotsController : Controller
    {
        private readonly ICrewingService service;

        public PilotsController(ICrewingService service)
        {
            this.service = service;
        }

        // GET: api/crews/pilots
        [HttpGet]
        public IActionResult GetAllPilots()
        {
            var pilots = service.GetAllPilots();
            return pilots == null ? NotFound("No pilots found!") as IActionResult : Ok(pilots);
        }

        // GET: api/crews/pilots/:id
        [HttpGet("{id}", Name = "GetPilot")]
        public IActionResult GetPilot(int id)
        {
            var pilot = service.GetPilot(id);
            return pilot == null ? NotFound($"Pilot with id = {id} not found!") as IActionResult : Ok(pilot);
        }

        // POST: api/crews/pilots
        [HttpPost]
        public IActionResult AddPilot([FromBody]Pilot pilot)
        {
            var entity = service.AddPilot(pilot);
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }

        // PUT: api/crews/pilots/:id
        [HttpPut("{id}")]
        public void ModifyPilot(int id, [FromBody]Pilot pilot)
        {
            var entity = service.ModifyPilot(pilot);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
        }

        // DELETE: api/crews/pilots/5
        [HttpDelete("{id}")]
        public IActionResult DeletePilot(int id)
        {
            var entity = service.DeletePilot(id);
            return entity == null ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
