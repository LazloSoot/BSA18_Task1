using System;
using System.Collections.Generic;

namespace ProjectStructure.Infrastructure.Shared
{
    public class FlightDTO
    {
        public long Id { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public IEnumerable<long> TicketsIds { get; set; }

        public FlightDTO()
        {
            TicketsIds = new List<long>();
        }
    }
}
