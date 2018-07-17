using System;

namespace ProjectStructure.Domain
{
    public class Stewardess : Entity
    {
        public string Name { get; set; }
        public string  Surname { get; set; }
        public DateTime Birth { get; set; }
        public Crew Crew { get; set; }
        public long? CrewId { get; set; }
    }
}