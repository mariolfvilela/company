using System;
using Company.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Company.Infra.Data
{
    public class CompanyDbContextFactory : IDesignTimeDbContextFactory<ContextCompany>
    {
        public ContextCompany CreateDbContext(string[] args)
        {
            //https://medium.com/@speedforcerun/implementing-idesigntimedbcontextfactory-in-asp-net-core-2-0-2-1-3718bba6db84
            var builder = new DbContextOptionsBuilder<ContextCompany>();
            builder.UseMySql("server=127.0.0.1;port=3306;database=company;user=root;password=122404M0;CharSet=utf8;SslMode=none;");
            return new ContextCompany(builder.Options);
        }
    }
}
