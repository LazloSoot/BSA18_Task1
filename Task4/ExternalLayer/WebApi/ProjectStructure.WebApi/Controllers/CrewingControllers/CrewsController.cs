using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.crewingRoute)]
    public class CrewsController : Controller
    {
        // GET: api/crews
        [HttpGet]
        public IEnumerable<string> GetAllCrews()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/crews/:id
        [HttpGet("{id}", Name = "GetCrew")]
        public string GetCrew(int id)
        {
            return "value";
        }
        
        // POST: api/crews
        [HttpPost]
        public void AddCrew([FromBody]string value)
        {
        }
        
        // PUT: api/crews/:id
        [HttpPut("{id}")]
        public void ModifyCrew(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/crews/:id
        [HttpDelete("{id}")]
        public void DeleteCrew(int id)
        {
        }
    }
}
