using System;
using Company.Domain.Entities;
using Company.Domain.Interfaces.Repositories;
using Company.Infra.Data.Context;

namespace Company.Infra.Data.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CompanyContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
