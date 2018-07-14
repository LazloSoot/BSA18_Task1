using System.Collections.Generic;

namespace ProjectStructure.Domain
{
    public class PlaneType : Entity
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int CargoCapacity { get; set; }
        public ICollection<Plane> Planes { get; set; }

        public PlaneType()
        {
            Planes = new List<Plane>();
        }
    }
}