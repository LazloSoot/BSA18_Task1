using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.crewingRoute + "/stewardesses")]
    public class StewardessesController : Controller
    {
        // GET: api/crews/stewardesses
        [HttpGet]
        public IEnumerable<string> GetAllStewardesses()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/crews/stewardesses/:id
        [HttpGet("{id}", Name = "GetStewardess")]
        public string GetStewardess(int id)
        {
            return "value";
        }

        // POST: api/crews/stewardesses
        [HttpPost]
        public void AddStewardess([FromBody]string value)
        {
        }

        // PUT: api/crews/stewardesses/:id
        [HttpPut("{id}")]
        public void ModifyStewardess(int id, [FromBody]string value)
        {
        }

        // DELETE: api/crews/stewardesses/:id
        [HttpDelete("{id}")]
        public void DeleteStewardess(int id)
        {
        }
    }
}
