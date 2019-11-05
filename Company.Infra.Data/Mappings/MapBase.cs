using System;
using Company.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Infra.Data.Mappings
{
    internal class MapBase<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
        {
            public virtual void Configure(EntityTypeBuilder<T> builder)
            {
                builder.HasKey(c => c.Id);

                builder.Property(c => c.Id).IsRequired().HasColumnName("ID");
                builder.Property(c => c.CreationDate).IsRequired().HasColumnName("CREATED");
                builder.Property(c => c.LastModifiedDate).HasColumnName("LASTMODIFIED");
            //builder.Property(c => c.LastModified).HasColumnName("LASTMODIFIED").IsRequired().HasColumnType("datetime2(0)");

            ///.NET Core, Identity and MySQL on MacOS
            //https://dev.to/ijason/net-core-identity-and-mysql-on-macos-4a3i
        }
    }
}
