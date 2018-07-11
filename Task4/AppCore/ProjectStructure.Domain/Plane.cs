using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Domain
{
    public class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlaneType Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Lifetime { get; set; }
    }
}
    