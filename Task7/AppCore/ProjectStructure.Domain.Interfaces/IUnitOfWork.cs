using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStructure.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken ct = default(CancellationToken));
    }
}
