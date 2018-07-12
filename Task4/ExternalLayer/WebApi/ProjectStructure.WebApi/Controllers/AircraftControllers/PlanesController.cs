using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.aircraftRoute)]
    public class PlanesController : Controller
    {
        private readonly IAircraftService service;

        public PlanesController(IAircraftService service)
        {
            this.service = service;
        }

        // GET: api/planes
        [HttpGet]
        public IActionResult GetAllPlanes()
        {
            var planes = service.GetAllPlanesInfo();
            return planes == null ? NotFound("Hangar is empty!") as IActionResult : Ok(planes);
        }

        // GET: api/planes/:id
        [HttpGet("{id}", Name = "GetPlane")]
        public IActionResult GetPlane(int id)
        {
            var plane = service.GetPlaneInfo();
            return plane == null ? NotFound($"Plane with id = {id} not found!") as IActionResult : Ok(plane);
        }
        
        // POST: api/planes
        [HttpPost]
        public IActionResult AddPlane([FromBody]Plane plane)
        {
            var entity = service.AddPlane(plane);
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }
        
        // PUT: api/planes/:id
        [HttpPut("{id}")]
        public IActionResult ModifyPlane(int id, [FromBody]Plane plane)
        {
            var entity = service.ModifyPlaneInfo(plane);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
        }
        
        // DELETE: api/planes/:id
        [HttpDelete("{id}")]
        public IActionResult DeletePlane(int id)
        {
            var successful = service.TryDeletePlane(id);
            return successful ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
