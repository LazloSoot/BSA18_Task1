using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.crewingRoute + "/pilots")]
    public class PilotsController : Controller
    {
        // GET: api/crews/pilots
        [HttpGet]
        public IEnumerable<string> GetAllPilots()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/crews/pilots/:id
        [HttpGet("{id}", Name = "GetPilot")]
        public string GetPilot(int id)
        {
            return "value";
        }

        // POST: api/crews/pilots
        [HttpPost]
        public void AddPilot([FromBody]string value)
        {
        }

        // PUT: api/crews/pilots/:id
        [HttpPut("{id}")]
        public void ModifyPilot(int id, [FromBody]string value)
        {
        }

        // DELETE: api/crews/pilots/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
