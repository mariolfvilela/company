using System;
using Company.Domain.Entities;
using Company.Domain.Interfaces.Repositories;
using Company.Infra.Data.Context;

namespace Company.Infra.Data.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ContextCompany contexto)
            : base(contexto)
        {
        }

        public Customer GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
