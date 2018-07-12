using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers.FlightOpControllers
{
    [Produces("application/json")]
    [Route(RouteConstants.flightOperations + "/tickets")]
    public class TicketsController : Controller
    {
        // GET: api/flights/tickets
        [HttpGet]
        public IEnumerable<string> GetAllTickets()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/flights/tickets/:id
        [HttpGet("{id}", Name = "GetTicket")]
        public string GetTicket(int id)
        {
            return "value";
        }
        
        // POST: api/flights/tickets
        [HttpPost]
        public void AddTicket([FromBody]string value)
        {
        }
        
        // PUT: api/flights/tickets/:id
        [HttpPut("{id}")]
        public void ModifyTicket(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/flights/tickets/:id
        [HttpDelete("{id}")]
        public void DeleteTicket(int id)
        {
        }
    }
}
