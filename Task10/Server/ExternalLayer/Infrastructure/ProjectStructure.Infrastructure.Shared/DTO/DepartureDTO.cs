using System;
using Newtonsoft.Json;

namespace ProjectStructure.Infrastructure.Shared
{
    public class DepartureDTO
    {
        public long Id { get; set; }
        [JsonProperty("Flight")]
        public long FlightId { get; set; }
        [JsonProperty("Time")]
        public DateTime DepartureTime { get; set; }
        [JsonProperty("Crew")]
        public long CrewId { get; set; }
        [JsonProperty("Plane")]
        public long PlaneId { get; set; }
    }
}