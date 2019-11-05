using System;
using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Infra.Data.Mappings
{
    internal class ProductMap : MapBase<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");

            builder.Property(e => e.Name).HasMaxLength(25); 

            builder.OwnsOne(e => e.Price, b =>
            {
                b.Property(e => e.Amount).HasColumnName("Price");
                b.OwnsOne(e => e.Currency, bc =>
                {
                    bc.Property(e => e.Symbol).HasColumnName("CurrencySymbol").HasMaxLength(25);
                    bc.Property(e => e.Name).HasColumnName("CurrencyName").HasMaxLength(25);
                });
            });
        }
    }
}