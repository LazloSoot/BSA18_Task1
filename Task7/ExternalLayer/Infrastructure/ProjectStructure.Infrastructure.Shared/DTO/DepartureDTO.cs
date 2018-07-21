using System;

namespace ProjectStructure.Infrastructure.Shared
{
    public class DepartureDTO
    {
        public long Id { get; set; }
        public long FlightId { get; set; }
        public DateTime DepartureTime { get; set; }
        public long CrewId { get; set; }
        public long PlaneId { get; set; }
    }
}