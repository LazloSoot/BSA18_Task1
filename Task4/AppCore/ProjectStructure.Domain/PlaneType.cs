using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Domain
{
    public class PlaneType
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int CargoCapacity { get; set; }
    }
}