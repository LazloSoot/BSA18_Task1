using System.Collections.Generic;

namespace ProjectStructure.Domain
{
    public class Crew : Entity
    {
        public Pilot Pilot { get; set; }
        public virtual ICollection<Stewardess> Stewardesses { get; set; }

        public Crew()
        {

        }

        public Crew(Pilot pilot, ICollection<Stewardess> stewardesses)
        {
            this.Pilot = pilot;
            this.Stewardesses = stewardesses;
        }
    }
}
