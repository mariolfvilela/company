using System;
using System.Threading.Tasks;
using Company.Domain.Interfaces.Repositories;
using Company.Infra.Data.Context;

namespace Company.Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextCompany _context;

        public UnitOfWork(ContextCompany context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
