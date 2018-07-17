using System;

namespace ProjectStructure.Domain
{
    public class Departure : Entity
    {
        public Flight Flight { get; set; }
        public long? FlightId { get; set; }
        public DateTime DepartureTime { get; set; }
        public Crew Crew { get; set; }
        public long? CrewId { get; set; }
        public Plane Plane { get; set; }
        public long? PlaneId { get; set; }

        public Departure()
        {

        }

        public Departure(Crew crew, Plane plane)
        {
            this.Crew = crew;
            this.Plane = plane;
        }
    }
}