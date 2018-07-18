using Newtonsoft.Json;
using System;
namespace ProjectStructure.Infrastructure.Shared
{
    public class PilotDTO
    {
        [JsonIgnore]
        public long Id { get; set; }

        [JsonProperty("FirstName")]
        public string Name { get; set; }

        [JsonProperty("LastName")]
        public string Surname { get; set; }

        [JsonProperty("BirthDate")]
        public DateTime Birth { get; set; }

        [JsonProperty("Exp")]
        public int ExperienceYears { get; set; }

    }
}
