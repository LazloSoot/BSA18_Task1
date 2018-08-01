using System.Collections.Generic;

namespace AirportUI.Models.Entities
{
    public class Crew
    {
        public long Id { get; set; }

        public long Pilot { get; set; }
        public IEnumerable<long> Stewardesses { get; set; }

        public Crew()
        {
            Stewardesses = new List<long>();
        }
        public Crew Clone() => (Crew)MemberwiseClone();
    }
}
