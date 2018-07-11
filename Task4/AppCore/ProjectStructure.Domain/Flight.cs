using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Domain
{
    public class Flight
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
