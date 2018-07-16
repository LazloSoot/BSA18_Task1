using System.Collections.Generic;

namespace ProjectStructure.Infrastructure.Shared
{
    public class CrewDTO
    {
        public long Id { get; set; }
        public PilotDTO Pilot { get; set; }
        public virtual ICollection<StewardessDTO> Stewardesses { get; set; }

        public CrewDTO()
        {
            Stewardesses = new List<StewardessDTO>();
        }
    }
}
