using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.WebApi.Helpers;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared;

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
        public IActionResult GetAllPlaneTypes()
        {
            var planeTypes = service.GetAllPlaneTypesInfo();
            return planeTypes == null ? NotFound("There is no information about plane types yet!") as IActionResult
                : Ok(mapper.Map<IEnumerable<PlaneTypeDTO>>(planeTypes));
        }

        // GET: api/planes/planeTypes/:id
        [HttpGet("planeTypes/{id}", Name = "GetPlaneType")]
        public IActionResult GetPlaneType(long id)
        {
            var planeType = service.GetPlaneTypeInfo(id);
            return planeType == null ? NotFound($"Plane type information with id = {id} not found!") as IActionResult
                : Ok(mapper.Map<PlaneTypeDTO>(planeType));
        }

        // POST: api/planes/planeTypes
        [HttpPost("planeTypes")]
        public IActionResult AddPlaneType([FromBody]PlaneTypeDTO type)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = service.AddPlaneType(mapper.Map<PlaneType>(type));
            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<PlaneTypeDTO>(entity));
        }

        // PUT: api/planes/planeTypes/:id
        [HttpPut("planeTypes/{id}")]
        public IActionResult ModifyPlaneType([FromBody]PlaneTypeDTO type)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = service.ModifyPlaneType(mapper.Map<PlaneType>(type));
            return entity == null ? StatusCode(304) as IActionResult
                : Ok(mapper.Map<PlaneTypeDTO>(entity));
        }

        // DELETE: api/planes/planeTypes/:id
        [HttpDelete("planeTypes/{id}")]
        public IActionResult DeletePlaneType(long id)
        {
            var success = service.TryDeletePlaneType(id);
            return success ? Ok() : StatusCode(304) as IActionResult;
        }
    }
}
