using System;
using System.Linq;
using Company.Domain.Entities;
using Company.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Company.Infra.Data.Context
{
    public class ContextCompany : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public IDbContextTransaction Transaction { get; private set; }

        public ContextCompany(DbContextOptions<ContextCompany> options)
            : base(options)
        {
            if (Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"server=127.0.0.1;port=8889;database=IdentityDB;user=root;password=<YOUR_PASSWORD>;CharSet=utf8;SslMode=none;"
            optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=company;user=root;password=122404M0;CharSet=utf8;SslMode=none;");
            //optionsBuilder.UseMySql("server=localhost;port=3306;database=company;uid=root;password=122404M0");
        }

        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("Created").IsModified = false;
                }
            };

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("LastModified") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("LastModified").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Added)
                {
                    entry.Property("LastModified").IsModified = false;
                }
            };
            return base.SaveChanges();
        }

        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerMap());
        }

    }
}
