using System;
using Microsoft.EntityFrameworkCore;

namespace Company.Infra.Data
{
    public static class DbContextUtils
    {
        public static TDb Create<TDb>(string connStr, Func<DbContextOptions<TDb>, TDb> creator) where TDb : DbContext
        {
            var options = new DbContextOptionsBuilder<TDb>()
                .UseMySql(connStr)
                .Options;

            var dbContext = creator(options);
            return dbContext;
        }
    }
}
