using System;
using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Infra.Data.Mappings
{
    public class CustomerMap : MapBase<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.ToTable("Customer");
            builder.Property(c => c.Name).IsRequired().HasColumnName("NAME").HasColumnType("varchar(150)").HasMaxLength(150);
            builder.Property(c => c.Email).IsRequired().HasColumnName("EMAIL").HasColumnType("varchar(150)").HasMaxLength(150);
            builder.Property(c => c.Phone).IsRequired().HasColumnName("PHONE").HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(c => c.BirthDate).HasColumnName("BirthDate").IsRequired().HasColumnType("datetime2(0)");
        }
    }
}
