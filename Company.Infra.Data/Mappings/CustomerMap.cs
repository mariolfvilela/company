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
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(100);
            builder.Property(c => c.Phone).IsRequired().HasColumnName("Phone");
        }
    }
}
