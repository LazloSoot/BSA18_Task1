using Newtonsoft.Json;
using System;

namespace ProjectStructure.Infrastructure.Shared
{
    public class StewardessDTO
    {
        public long Id { get; set; }

        [JsonProperty("FirstName")]
        public string Name { get; set; }

        [JsonProperty("LastName")]
        public string  Surname { get; set; }

        [JsonProperty("BirthDate")]
        public DateTime Birth { get; set; }
    }
}
