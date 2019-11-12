using System;
using System.Threading.Tasks;

namespace Company.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
