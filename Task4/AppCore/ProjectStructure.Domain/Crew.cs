using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Domain
{
    public class Crew
    {
        public int Id { get; set; }
        public Pilot Pilot { get; set; }
        public IEnumerable<Stewardess> Stewardesses { get; set; }
    }
}
