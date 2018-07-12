using System;

namespace ProjectStructure.Domain
{
    public class Plane : Entity
    {
        // public int Id { get; set; }
        public string Name { get; set; }
        public PlaneType Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Lifetime { get; set; }

        public Plane(PlaneType type)
        {
            this.Type = type;
        }
    }
}
    