using System;
namespace ProjectStructure.Infrastructure.Shared.DTO
{
    public class PilotDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public int ExperienceYears { get; set; }

    }
}
