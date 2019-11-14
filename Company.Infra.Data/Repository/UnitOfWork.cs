using System;
using System.Threading.Tasks;
using Company.Domain.Interfaces.Repositories;
using Company.Infra.Data.Context;

namespace Company.Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextCompany _context;

        private CustomerRepository _customerRepository;
        private UserRepository _userRepository;

        public UnitOfWork(ContextCompany context)
        {
            _context = context;
        }

        public CustomerRepository Musics => _customerRepository = _customerRepository ?? new CustomerRepository(_context);

        public UserRepository Artists => _userRepository = _userRepository ?? new UserRepository(_context);


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
