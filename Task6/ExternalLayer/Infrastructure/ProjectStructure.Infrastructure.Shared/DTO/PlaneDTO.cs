using System;

namespace ProjectStructure.Infrastructure.Shared
{
    public class PlaneDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Lifetime { get; set; }
        public DateTime LastMaintenance { get; set; }
        public int FlightHours { get; set; }
        public long? PlaneTypeId { get; set; }
      //  public PlaneTypeDTO Type { get; set; }
    }
}
    