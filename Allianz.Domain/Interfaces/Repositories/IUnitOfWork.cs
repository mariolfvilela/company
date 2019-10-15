using System;
namespace Company.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
