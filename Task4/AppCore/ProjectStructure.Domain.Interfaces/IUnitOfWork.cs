using System.Threading.Tasks;

namespace ProjectStructure.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> Set<T>() where T : Entity;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
