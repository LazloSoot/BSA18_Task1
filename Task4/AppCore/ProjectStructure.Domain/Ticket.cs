using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Domain
{
    public class Ticket : Entity
    {
        //public int Id { get; set; }
        public double Price { get; set; }
        public int FlightId { get; set; }
    }
}