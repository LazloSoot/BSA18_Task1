using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers.FlightOpControllers
{
    [Produces("application/json")]
    [Route(RouteConstants.flightOperations)]
    public class FlightsController : Controller
    {
        // GET: api/flights
        [HttpGet]
        public IEnumerable<string> GetAllFlights()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/flights/:id
        [HttpGet("{id}", Name = "GetFlight")]
        public string GetFlight(int id)
        {
            return "value";
        }
        
        // POST: api/flights
        [HttpPost]
        public void AddFlight([FromBody]string value)
        {
        }
        
        // PUT: api/flights/:id
        [HttpPut("{id}")]
        public void ModifyFlight(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/flights
        [HttpDelete("{id}")]
        public void DeleteFlight(int id)
        {
        }
    }
}
