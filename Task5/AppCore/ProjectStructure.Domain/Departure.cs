using System;

namespace ProjectStructure.Domain
{
    public class Departure : Entity
    {
        //public int Id { get; set; }
        public int FlightId { get; set; }
        public DateTime DepartureTime { get; set; }
        public Crew Crew { get; set; }
        public Plane Plane { get; set; }

        public Departure(Crew crew, Plane plane)
        {
            this.Crew = crew;
            this.Plane = plane;
        }
    }
}