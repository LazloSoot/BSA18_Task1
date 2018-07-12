using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers
{
    [Produces("application/json")]
    [Route(RouteConstants.aircraftRoute)]
    public class PlanesController : Controller
    {
        // GET: api/planes
        [HttpGet]
        public IEnumerable<string> GetAllPlanes()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/planes/:id
        [HttpGet("{id}", Name = "GetPlane")]
        public string GetPlane(int id)
        {
            return "value";
        }
        
        // POST: api/planes
        [HttpPost]
        public void AddPlane([FromBody]string value)
        {
        }
        
        // PUT: api/planes/:id
        [HttpPut("{id}")]
        public void ModifyPlane(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/planes/:id
        [HttpDelete("{id}")]
        public void DeletePlane(int id)
        {
        }
    }
}
