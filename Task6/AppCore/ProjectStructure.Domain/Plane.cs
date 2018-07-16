using System;

namespace ProjectStructure.Domain
{
    public class Plane : Entity
    {
        public string Name { get; set; }
        public PlaneType Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime LastHeavyMaintenance { get; set; }
        public int FlightHours  { get; set; }
        public TimeSpan Lifetime { get; set; }
        public long? TypeId { get; set; }

        public Plane()
        {

        }
        public Plane(PlaneType type)
        {
            this.Type = type;
        }
    }
}
    