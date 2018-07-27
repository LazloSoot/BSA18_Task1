namespace ProjectStructure.Domain.Interfaces
{
    public interface IDbCrewingUnitOfWork : IUnitOfWork
    {
        IDbRepository<Crew> Crews { get; }
        IDbRepository<Pilot> Pilots { get; }
        IDbRepository<Stewardess> Stewardesses { get; }
    }
}
