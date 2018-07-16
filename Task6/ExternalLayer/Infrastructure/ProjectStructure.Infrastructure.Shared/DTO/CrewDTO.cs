using System.Collections.Generic;

namespace ProjectStructure.Infrastructure.Shared
{
    public class CrewDTO
    {
        public long Id { get; set; }
        public long PilotId { get; set; }
        public IEnumerable<long> StewardessesIds { get; set; }
        public CrewDTO()
        {
            StewardessesIds = new List<long>();
        }
    }
}
