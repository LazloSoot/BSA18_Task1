using System;

namespace AirportUI.Models.Entities
{
    public class Plane
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long TypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime LastHeavyMaintenance { get; set; }
        public int FlightHours { get; set; }
        public TimeSpan Lifetime { get; set; }

        public Plane Clone() => (Plane)MemberwiseClone();
    }
}
