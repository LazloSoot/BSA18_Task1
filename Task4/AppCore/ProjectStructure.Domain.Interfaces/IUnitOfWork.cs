using System;
using System.Threading.Tasks;

namespace ProjectStructure.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
