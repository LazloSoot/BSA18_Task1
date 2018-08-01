using System;

namespace AirportUI.Models.Entities
{
    public class Departure
    {
        public long Id { get; set; }
        public long FlightId { get; set; }
        public DateTime DepartureTime { get; set; }
        public long CrewId { get; set; }
        public long PlaneId { get; set; }

        public Departure Clone() => (Departure)MemberwiseClone();
    }
}
