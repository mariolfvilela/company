using System;
using Company.Infra.Data.Context;
using System.Threading.Tasks;
using Company.Domain.Entities;

namespace Company.Infra.Data
{
    public class CompanyRepository : IAsyncDisposable
    {
        private readonly ContextCompany _dbContext;

        public CompanyRepository(string connStr)
        {
            _dbContext = CreateCommerceDbContext(connStr);
        }

        private static ContextCompany CreateCommerceDbContext(string connStr) => DbContextUtils.Create<ContextCompany>(connStr, o => new ContextCompany(o));

        public async Task CreateCustomer(Customer customer)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("creating customer...");

            //_dbContext.Customers.Add(customer);
            //await _dbContext.SaveChangesAsync();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"customer {customer.Id} created!");

            Console.ResetColor();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext?.DisposeAsync() ?? default;
        }
    }
}
