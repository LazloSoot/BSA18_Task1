using System;
using System.Threading.Tasks;

namespace ProjectStructure.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Set<T>() where T : Entity;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
