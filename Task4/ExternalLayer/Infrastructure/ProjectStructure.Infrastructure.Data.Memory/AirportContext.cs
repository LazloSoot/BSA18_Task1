using ProjectStructure.Domain;
using System;
using System.Collections.Generic;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public sealed class AirportContext : IDisposable
    {
        public IEnumerable<Flight> Flights { get; set; }
        public IEnumerable<Departure> Departures { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
              
        public IEnumerable<Plane> Planes { get; set; }
        public IEnumerable<PlaneType> PlaneTypes { get; set; }
              
        public IEnumerable<Crew> Crews { get; set; }
        public IEnumerable<Pilot> Pilots { get; set; }
        public IEnumerable<Stewardess> Stewardesses { get; set; }

        public void Dispose()
        {
            
        }
    }
}
