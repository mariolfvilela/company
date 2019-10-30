using System;
using Company.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Infra.Data.Mappings
{
        public class MapBase<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
        {
            public virtual void Configure(EntityTypeBuilder<T> builder)
            {
                builder.HasKey(c => c.Id);

                builder.Property(c => c.Id).IsRequired().HasColumnName("ID");
            builder.Property(c => c.Created).IsRequired().HasColumnName("CREATED").HasColumnType("datetime2");
            //builder.Property(c => c.Created).IsRequired().HasColumnName("CREATED").HasColumnType("datetime2(0)");
                //builder.Property(c => c.LastModified).HasField("LAST_MODIFIED");
                builder.Property(c => c.LastModified).HasColumnName("LASTMODIFIED").IsRequired().HasColumnType("datetime2(0)");
            }
        }
}
