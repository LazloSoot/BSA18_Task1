namespace ProjectStructure.Domain.Interfaces
{
    public interface IFlightOperationsUnitOfWork : IUnitOfWork
    {
        IRepository<Flight> Flights { get; }
        IRepository<Ticket> Tickets { get; }
        IRepository<Departure> Departures { get; }
    }
}
