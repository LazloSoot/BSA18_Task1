namespace ProjectStructure.Domain
{
    public class Ticket : Entity
    {
        public double Price { get; set; }
        public int Seat { get; set; }
        public long? FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}