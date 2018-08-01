using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectStructure.Infrastructure.Shared
{
    public class FlightDTO
    {
        public long Id { get; set; }
        [JsonProperty("From")]
        public string DeparturePoint { get; set; }
        [JsonProperty("Date")]
        public DateTime DepartureTime { get; set; }
        [JsonProperty("To")]
        public string Destination { get; set; }
        [JsonProperty("Arrival")]
        public DateTime ArrivalTime { get; set; }
        public IEnumerable<long> TicketsIds { get; set; }

        public FlightDTO()
        {
            TicketsIds = new List<long>();
        }
    }
}
