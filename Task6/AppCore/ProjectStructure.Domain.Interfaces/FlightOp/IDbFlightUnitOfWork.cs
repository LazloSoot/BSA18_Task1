namespace ProjectStructure.Domain.Interfaces
{
    public interface IDbFlightOperationsUnitOfWork : IUnitOfWork
    {
        IDbRepository<Flight> Flights { get; }
        IDbRepository<Ticket> Tickets { get; }
        IDbRepository<Departure> Departures { get; }
    }
}
