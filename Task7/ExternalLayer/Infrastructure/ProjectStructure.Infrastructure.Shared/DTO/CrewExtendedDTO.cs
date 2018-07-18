using Newtonsoft.Json;
using System.Collections.Generic;


namespace ProjectStructure.Infrastructure.Shared
{
    public class CrewExtendedDTO
    {
        [JsonIgnore]
        public long Id { get; set; }

        [JsonProperty("Pilot")]
        public PilotDTO PilotDto { get; set; }

        [JsonProperty("Stewardess")]
        public IEnumerable<StewardessDTO> StewardessesDtos { get; set; }

        public CrewExtendedDTO()
        {
            StewardessesDtos = new List<StewardessDTO>();
        }
    }
}
