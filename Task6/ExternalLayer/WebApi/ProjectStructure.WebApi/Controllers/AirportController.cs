using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared;

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
        public IActionResult SheduleDeparture([FromBody]DepartureDTO departure)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            Departure entity;
            try
            {
                entity = service.SheduleDeparture(mapper.Map<Departure>(departure));
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return entity == null ? StatusCode(409) as IActionResult
                : Created($"{Request?.Scheme}://{Request?.Host}{Request?.Path}{entity.Id}",
                mapper.Map<DepartureDTO>(entity));
        }
        
        // PUT: api/Airport/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/airport
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            bool success;
            try
            {
                success = service.DeleteDeparture(id);
            }
            catch (System.ArgumentException ex)
            {
                return StatusCode(500, ex.Message) as IActionResult;
            }
            return success ? Ok() : StatusCode(304) as IActionResult;
        }
    }
}
