using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Domain
{
    public class Departure : Entity
    {
        //public int Id { get; set; }
        public int FlightId { get; set; }
        public DateTime DepartureTime { get; set; }
        public Crew Crew { get; set; }
        public Plane Plane { get; set; }
    }
}