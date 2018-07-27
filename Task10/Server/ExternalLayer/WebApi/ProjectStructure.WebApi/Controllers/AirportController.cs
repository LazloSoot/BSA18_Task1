using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using System.Threading.Tasks;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.airportRoute)]
    public class AirportController : Controller
    {
        private readonly Airport service;
        private readonly IMapper mapper;

        public AirportController(IMapper mapper, Airport airportService)
        {
            this.mapper = mapper;
            this.service = airportService;
        }
        
        // POST: api/airport
        [HttpPost]
        public async Task<IActionResult> SheduleDeparture([FromBody]DepartureDTO departure)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            Departure entity;
            try
            {
                entity = await service.SheduleDepartureAsync(mapper.Map<Departure>(departure));
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<DepartureDTO>(entity));
        }
        
        // PUT: api/Airport/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyDeparture(long id, [FromBody]DepartureDTO departure)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var entity = await service.ModifyDepartureAsync(id, mapper.Map<Departure>(departure));
            return entity == null ? StatusCode(304) as IActionResult
                : Ok(mapper.Map<DepartureDTO>(entity));
        }

        // DELETE: api/airport/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeparture(long id)
        {
            var success = await service.DeleteDepartureAsync(id);
            return success ? Ok() : StatusCode(304) as IActionResult;
        }
    }
}
