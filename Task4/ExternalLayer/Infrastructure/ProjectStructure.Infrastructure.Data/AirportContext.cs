using Microsoft.EntityFrameworkCore;
using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.Data
{
    public sealed class AirportContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneType> PlaneTypes { get; set; }

        public DbSet<Crew> Crews { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Stewardess> Stewardesses { get; set; }
    }
}
