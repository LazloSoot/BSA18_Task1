using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.WebApi.Helpers;

namespace ProjectStructure.WebApi.Controllers.AircraftControllers
{
    [Produces("application/json")]
    [Route(RouteConstants.aircraftRoute + "/planeTypes")]
    public class PlaneTypesController : Controller
    {
        // GET: api/planes/planeTypes
        [HttpGet]
        public IEnumerable<string> GetAllPlaneTypes()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/planes/planeTypes/:id
        [HttpGet("{id}", Name = "GetPlaneType")]
        public string GetPlaneType(int id)
        {
            return "value";
        }

        // POST: api/planes/planeTypes
        [HttpPost]
        public void AddPlaneType([FromBody]string value)
        {
        }

        // PUT: api/planes/planeTypes/:id
        [HttpPut("{id}")]
        public void ModifyPlaneType(int id, [FromBody]string value)
        {
        }

        // DELETE: api/planes/planeTypes/:id
        [HttpDelete("{id}")]
        public void DeletePlaneType(int id)
        {
        }
    }
}
