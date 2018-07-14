namespace ProjectStructure.Infrastructure.Shared
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public FlightDTO Flight { get; set; }
        public long? FlightDTOId { get; set; }
    }
}