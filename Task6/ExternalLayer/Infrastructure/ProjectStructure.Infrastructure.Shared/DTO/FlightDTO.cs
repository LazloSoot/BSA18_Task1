using System;
using System.Collections.Generic;

namespace ProjectStructure.Infrastructure.Shared
{
    public class FlightDTO
    {
        public long Id { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public virtual ICollection<TicketDTO> Tickets { get; set; }

        public FlightDTO()
        {
            Tickets = new List<TicketDTO>();
        }

    }
}
