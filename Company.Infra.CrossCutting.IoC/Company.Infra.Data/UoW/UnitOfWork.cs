using System;
using Company.Domain.Interfaces.Repositories;
using Company.Infra.Data.Context;

namespace Company.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CompanyContext _context;

        public UnitOfWork(CompanyContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
