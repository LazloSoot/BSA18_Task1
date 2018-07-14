using System;

namespace ProjectStructure.Infrastructure.Shared
{
    public class DepartureDTO
    {
        public long Id { get; set; }
        public FlightDTO Flight { get; set; }
        public DateTime DepartureTime { get; set; }
        public CrewDTO Crew { get; set; }
        public PlaneDTO Plane { get; set; }
    }
}