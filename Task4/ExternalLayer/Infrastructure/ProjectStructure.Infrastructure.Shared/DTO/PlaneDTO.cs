using System;

namespace ProjectStructure.Infrastructure.Shared.DTO
{
    public class PlaneDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long TypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Lifetime { get; set; }
    }
}
    