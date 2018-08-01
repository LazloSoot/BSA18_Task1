using System;

namespace AirportUI.Models.Entities
{
    public class Stewardess
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Stewardess Clone() => (Stewardess)MemberwiseClone();
    }
}
