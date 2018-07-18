using System.Collections.Generic;

namespace ProjectStructure.Infrastructure.Shared
{
    public class CrewExtendedDTO
    {
        public long Id { get; set; }
        public PilotDTO PilotDto { get; set; }
        public IEnumerable<StewardessDTO> StewardessesDtos { get; set; }

        public CrewExtendedDTO()
        {
            StewardessesDtos = new List<StewardessDTO>();
        }
    }
}
