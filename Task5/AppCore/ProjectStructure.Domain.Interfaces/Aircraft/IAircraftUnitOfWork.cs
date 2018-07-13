namespace ProjectStructure.Domain.Interfaces
{
    public interface IAircraftUnitOfWork : IUnitOfWork
    {
        IRepository<Plane> Planes { get; }
        IRepository<PlaneType> PlaneTypes { get; }
    }
}
