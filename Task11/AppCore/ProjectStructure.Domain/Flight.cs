using System;
using System.Collections.Generic;

namespace ProjectStructure.Domain
{
    public class Flight : Entity
    {
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
