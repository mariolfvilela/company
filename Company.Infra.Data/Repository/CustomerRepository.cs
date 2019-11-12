using System;
using System.Linq;
using Company.Domain.Entities;
using Company.Domain.Interfaces.Repositories;
using Company.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

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
            return GetAll().AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
