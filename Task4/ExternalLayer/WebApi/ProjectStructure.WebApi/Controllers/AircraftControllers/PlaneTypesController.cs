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
    [Route(RouteConstants.aircraftRoute + "/planeTypes")]
    public class PlaneTypesController : Controller
    {
        private readonly IAircraftService service;

        public PlaneTypesController(IAircraftService service)
        {
            this.service = service;
        }

        // GET: api/planes/planeTypes
        [HttpGet]
        public IActionResult GetAllPlaneTypes()
        {
            var planeTypes = service.GetAllPlaneTypes();
            return planeTypes == null ? NotFound("There is no information about plane types yet!") as IActionResult : Ok(planeTypes);
        }

        // GET: api/planes/planeTypes/:id
        [HttpGet("{id}", Name = "GetPlaneType")]
        public IActionResult GetPlaneType(int id)
        {
            var planeType = service.GetPlaneType(id);
            return planeType == null ? NotFound($"Plane type information with id = {id} not found!") as IActionResult : Ok(planeType);
        }

        // POST: api/planes/planeTypes
        [HttpPost]
        public IActionResult AddPlaneType([FromBody]PlaneType type)
        {
            var entity = service.AddPlaneType(type);
            if (entity != null)
            {
                string uri = $"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}";
            }
            return entity == null ? StatusCode(409) as IActionResult : Created($"{Request.Scheme}://{Request.Host}{Request.Path}{entity.Id}", entity);
        }

        // PUT: api/planes/planeTypes/:id
        [HttpPut("{id}")]
        public void ModifyPlaneType(int id, [FromBody]PlaneType type)
        {
            var entity = service.ModifyPlaneType(id, type);
            return entity == null ? StatusCode(304) as IActionResult : Ok(entity);
        }

        // DELETE: api/planes/planeTypes/:id
        [HttpDelete("{id}")]
        public void DeletePlaneType(int id)
        {
            var entity = service.DeletePlaneType(id);
            return entity == null ? StatusCode(304) as IActionResult : Ok();
        }
    }
}
