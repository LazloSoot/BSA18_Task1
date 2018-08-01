using System;

namespace AirportUI.Models.Entities
{
    public class Pilot
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Exp { get; set; }

        public Pilot Copy() => this.MemberwiseClone() as Pilot;
    }
}