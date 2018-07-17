using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Domain;
using ProjectStructure.Infrastructure.Shared;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.aircraftRoute)]
    public class PlanesController : Controller
    {
        private readonly IAircraftService service;
        private readonly IMapper mapper;

        public PlanesController(IMapper mapper, IAircraftService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET: api/planes
        [HttpGet]
        public IActionResult GetAllPlanes()
        {
            var planes = service.GetAllPlanesInfo();
            return planes == null ? NotFound("Hangar is empty!") as IActionResult
                : Ok(mapper.Map<IEnumerable<PlaneDTO>>(planes));
        }

        // GET: api/planes/:id
        [HttpGet("{id}", Name = "GetPlane")]
        public IActionResult GetPlane(long id)
        {
            var plane = service.GetPlaneInfo(id);
            return plane == null ? NotFound($"Plane with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<PlaneDTO>(plane));
        }
        
        // POST: api/planes
        [HttpPost]
        public IActionResult AddPlane([FromBody]PlaneDTO plane)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            if(!plane.PlaneTypeId.HasValue)
                return BadRequest("Plane type have to be defined!") as IActionResult;

            //var targetType = service.GetPlaneTypeInfo(plane.PlaneTypeId.Value);
            //if (targetType == null)
            //    return NotFound($"Plane type with id = {plane.PlaneTypeId} not found!Plane not added!");
            //var newPlane = mapper.Map<Plane>(plane);
            //newPlane.Type = targetType;

            var entity = service.AddPlane(mapper.Map<Plane>(plane));
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<PlaneDTO>(entity));
        }
        
        // PUT: api/planes/:id
        [HttpPut("{id}")]
        public IActionResult ModifyPlane([FromBody]PlaneDTO plane)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            if (!plane.PlaneTypeId.HasValue)
                return BadRequest("Plane type have to be defined!") as IActionResult;

            var targetType = service.GetPlaneTypeInfo(plane.PlaneTypeId.Value);
            if (targetType == null)
                return NotFound($"Plane type with id = {plane.PlaneTypeId} not found!Plane not added!");
            var mPlane = mapper.Map<Plane>(plane);
            mPlane.Type = targetType;

            var entity = service.ModifyPlaneInfo(mPlane);
            return entity == null ? StatusCode(304) as IActionResult 
                : Ok(mapper.Map<PlaneDTO>(entity));
        }
        
        // DELETE: api/planes/:id
        [HttpDelete("{id}")]
        public IActionResult DeletePlane(long id)
        {
            var successful = service.TryDeletePlane(id);
            return successful ? Ok() : StatusCode(304) as IActionResult;
        }
    }
}
