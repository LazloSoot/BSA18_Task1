namespace ProjectStructure.Domain.Interfaces
{
    public interface IDbAircraftUnitOfWork : IUnitOfWork
    {
        IDbRepository<Plane> Planes { get; }
        IDbRepository<PlaneType> PlaneTypes { get; }
    }
}
