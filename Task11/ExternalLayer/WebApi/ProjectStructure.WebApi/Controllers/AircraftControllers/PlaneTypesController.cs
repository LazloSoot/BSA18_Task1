using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.WebApi.Helpers;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using System.Threading.Tasks;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.aircraftRoute)]
    public class PlaneTypesController : Controller
    {
        private readonly IAircraftService service;
        private readonly IMapper mapper;

        public PlaneTypesController(IMapper mapper,IAircraftService service)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/planes/planeTypes
        [HttpGet("planeTypes")]
        public async Task<IActionResult> GetAllPlaneTypes()
        {
            var planeTypes = await service.GetAllPlaneTypesInfoAsync();
            return planeTypes == null ? NotFound("There is no information about plane types yet!") as IActionResult
                : Ok(mapper.Map<IEnumerable<PlaneTypeDTO>>(planeTypes));
        }

        // GET: api/planes/planeTypes/:id
        [HttpGet("planeTypes/{id}", Name = "GetPlaneType")]
        public async Task<IActionResult> GetPlaneType(long id)
        {
            var planeType = await service.GetPlaneTypeInfoAsync(id);
            return planeType == null ? NotFound($"Plane type information with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<PlaneTypeDTO>(planeType));
        }

        // POST: api/planes/planeTypes
        [HttpPost("planeTypes")]
        public async Task<IActionResult> AddPlaneType([FromBody]PlaneTypeDTO type)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = await service.AddPlaneTypeAsync(mapper.Map<PlaneType>(type));
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<PlaneTypeDTO>(entity));
        }

        // PUT: api/planes/planeTypes/:id
        [HttpPut("planeTypes/{id}")]
        public async Task<IActionResult> ModifyPlaneType(long id, [FromBody]PlaneTypeDTO type)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = await service.ModifyPlaneTypeAsync(id, mapper.Map<PlaneType>(type));
            return entity == null ? StatusCode(304) as IActionResult
                : Ok(mapper.Map<PlaneTypeDTO>(entity));
        }

        // DELETE: api/planes/planeTypes/:id
        [HttpDelete("planeTypes/{id}")]
        public async Task<IActionResult> DeletePlaneType(long id)
        {
            var success = await service.TryDeletePlaneTypeAsync(id);
            return success ? Ok() : StatusCode(304) as IActionResult;
        }
    }
}
