using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.aircraftRoute)]
    public class PlaneTypesController : Controller
    {
        private readonly IAircraftService service;

        public PlaneTypesController(IAircraftService service)
        {
            this.service = service;
        }

        // GET: api/planes/planeTypes
        [HttpGet("planeTypes")]
        public IActionResult GetAllPlaneTypes()
        {
            var planeTypes = service.GetAllPlaneTypesInfo();
            return planeTypes == null ? NotFound("There is no information about plane types yet!") as IActionResult : Ok(planeTypes);
        }

        // GET: api/planes/planeTypes/:id
        [HttpGet("planeTypes/{id}", Name = "GetPlaneType")]
        public IActionResult GetPlaneType(int id)
        {
            var planeType = service.GetPlaneTypeInfo(id);
            return planeType == null ? NotFound($"Plane type information with id = {id} not found!") as IActionResult : Ok(planeType);
        }

        // POST: api/planes/planeTypes
        [HttpPost("planeTypes")]
        public IActionResult AddPlaneType([FromBody]PlaneType type)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.AddPlaneType(type);
            if (entity != null)
            {
                string uri = $"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}";
            }
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }

        // PUT: api/planes/planeTypes/:id
        [HttpPut("planeTypes/{id}")]
        public IActionResult ModifyPlaneType(int id, [FromBody]PlaneType type)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var entity = service.ModifyPlaneType(type);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
        }

        // DELETE: api/planes/planeTypes/:id
        [HttpDelete("planeTypes/{id}")]
        public IActionResult DeletePlaneType(int id)
        {
            var entity = service.TryDeletePlaneType(id);
            return entity ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
