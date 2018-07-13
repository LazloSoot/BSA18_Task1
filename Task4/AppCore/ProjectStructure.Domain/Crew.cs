using System.Collections.Generic;

namespace ProjectStructure.Domain
{
    public class Crew : Entity
    {
        //public int Id { get; set; }
        public Pilot Pilot { get; set; }
        public IEnumerable<Stewardess> Stewardesses { get; set; }

        public Crew(Pilot pilot, IEnumerable<Stewardess> stewardesses)
        {
            this.Pilot = pilot;
            this.Stewardesses = stewardesses;
        }
    }
}
