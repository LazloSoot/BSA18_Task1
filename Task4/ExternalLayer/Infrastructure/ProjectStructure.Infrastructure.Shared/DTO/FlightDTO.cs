using System;

namespace ProjectStructure.Infrastructure.Shared.DTO
{
    public class FlightDTO
    {
        public long Id { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
