using System;

namespace ProjectStructure.Domain
{
    public class DepartureDTO
    {
        public long Id { get; set; }
        public int FlightId { get; set; }
        public DateTime DepartureTime { get; set; }
        public long CrewId { get; set; }
        public long PlaneId { get; set; }
    }
}