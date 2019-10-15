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
            //builder.ToTable("Customer");
             
            builder.Property(c => c.Name)
                //.HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasField("NAME")
                .IsRequired();

            builder.Property(c => c.Email)
                //.HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasField("EMAIL")
                .IsRequired();
        }
    }
}
}
