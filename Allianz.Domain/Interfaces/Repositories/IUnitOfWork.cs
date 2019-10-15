using System;
namespace Allianz.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
