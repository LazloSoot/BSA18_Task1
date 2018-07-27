using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllPlanes()
        {
            var planes = await service.GetAllPlanesInfoAsync();
            return planes == null ? NotFound("Hangar is empty!") as IActionResult
                : Ok(mapper.Map<IEnumerable<PlaneDTO>>(planes));
        }

        // GET: api/planes/:id
        [HttpGet("{id}", Name = "GetPlane")]
        public async Task<IActionResult> GetPlane(long id)
        {
            var plane = await service.GetPlaneInfoAsync(id);
            return plane == null ? NotFound($"Plane with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<PlaneDTO>(plane));
        }
        
        // POST: api/planes
        [HttpPost]
        public async Task<IActionResult> AddPlane([FromBody]PlaneDTO plane)
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

            var entity = await service.AddPlaneAsync(mapper.Map<Plane>(plane));
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<PlaneDTO>(entity));
        }
        
        // PUT: api/planes/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyPlane(long id, [FromBody]PlaneDTO plane)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            if (!plane.PlaneTypeId.HasValue)
                return BadRequest("Plane type have to be defined!") as IActionResult;

            var targetType = await service.GetPlaneTypeInfoAsync(plane.PlaneTypeId.Value);
            if (targetType == null)
                return NotFound($"Plane type with id = {plane.PlaneTypeId} not found!Plane not added!");
            var mPlane = mapper.Map<Plane>(plane);
            mPlane.Type = targetType;

            var entity = await service.ModifyPlaneInfoAsync(id, mPlane);
            return entity == null ? StatusCode(304) as IActionResult 
                : Ok(mapper.Map<PlaneDTO>(entity));
        }
        
        // DELETE: api/planes/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlane(long id)
        {
            var successful = await service.TryDeletePlaneAsync(id);
            return successful ? Ok() : StatusCode(304) as IActionResult;
        }
    }
}
