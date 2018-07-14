using System;

namespace ProjectStructure.Infrastructure.Shared
{
    public class PlaneDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public PlaneTypeDTO Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Lifetime { get; set; }
    }
}
    