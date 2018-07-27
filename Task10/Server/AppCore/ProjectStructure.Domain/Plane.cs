using System;

namespace ProjectStructure.Domain
{
    public class Plane : Entity
    {
        private long lifeTimeTicks;
        public string Name { get; set; }
        public PlaneType Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime LastHeavyMaintenance { get; set; }
        public int FlightHours  { get; set; }
        public TimeSpan Lifetime { get => TimeSpan.FromTicks(lifeTimeTicks); set => lifeTimeTicks = value.Ticks; }
        public long LifeTimeTicks { get => lifeTimeTicks; set => lifeTimeTicks = value; }
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
    