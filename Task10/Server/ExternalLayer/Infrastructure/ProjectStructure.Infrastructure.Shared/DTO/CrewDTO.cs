using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectStructure.Infrastructure.Shared
{
    public class CrewDTO
    {
        public long Id { get; set; }
        [JsonProperty("Pilot")]
        public long PilotId { get; set; }
        [JsonProperty("Stewardesses")]
        public IEnumerable<long> StewardessesIds { get; set; }
        public CrewDTO()
        {
            StewardessesIds = new List<long>();
        }
    }
}
