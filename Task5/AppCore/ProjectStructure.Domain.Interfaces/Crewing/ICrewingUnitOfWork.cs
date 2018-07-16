namespace ProjectStructure.Domain.Interfaces
{
    public interface ICrewingUnitOfWork : IUnitOfWork
    {
        IRepository<Crew> Crews { get; }
        IRepository<Pilot> Pilots { get; }
        IRepository<Stewardess> Stewardesses { get; }
    }
}
