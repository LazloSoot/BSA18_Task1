namespace AirportUI.Models.Entities
{
    public class Ticket
    {
        public long Id { get; set; }
        public double Price { get; set; }
        public int Seat { get; set; }

        public Ticket Clone() => (Ticket)MemberwiseClone();
    }
}
