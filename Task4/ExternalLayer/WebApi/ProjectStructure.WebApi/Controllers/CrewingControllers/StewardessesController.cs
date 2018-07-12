using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.crewingRoute + "/stewardesses")]
    public class StewardessesController : Controller
    {
        private readonly ICrewingService service;

        public StewardessesController(ICrewingService service)
        {
            this.service = service;
        }
        // GET: api/crews/stewardesses
        [HttpGet]
        public IActionResult GetAllStewardesses()
        {
            var stewardesses = service.GetAllStewardesses();
            return stewardesses == null ? NotFound("No stewardesses found!") as IActionResult : Ok(stewardesses);
        }

        // GET: api/crews/stewardesses/:id
        [HttpGet("{id}", Name = "GetStewardess")]
        public IActionResult GetStewardess(int id)
        {
            var stewardess = service.GetStewardess(id);
            return stewardess == null ? NotFound($"Stewardess with id = {id} not found!") as IActionResult : Ok(stewardess);
        }

        // POST: api/crews/stewardesses
        [HttpPost]
        public void AddStewardess([FromBody]Stewardess stewardess)
        {
            var entity = service.AddStewardess(stewardess);
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }

        // PUT: api/crews/stewardesses/:id
        [HttpPut("{id}")]
        public void ModifyStewardess(int id, [FromBody]string value)
        {
        }

        // DELETE: api/crews/stewardesses/:id
        [HttpDelete("{id}")]
        public void DeleteStewardess(int id)
        {
        }
    }
}
