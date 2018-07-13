using System.Collections.Generic;

namespace ProjectStructure.Domain
{
    public class CrewDTO
    {
        public long Id { get; set; }
        public long PilotId { get; set; }
        public long[] StewardessesIds { get; set; }
    }
}
