using System;
using Microsoft.EntityFrameworkCore;
using Company.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Infra.Data.Mappings
{
    public class MapBase<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired().HasField("ID");
            builder.Property(c => c.Created).HasField("CREATED");
            builder.Property(c => c.LastModified).HasField("LAST_MODIFIED");
            // builder.Property(c => c.LastModified).HasColumnType("datetime2(0)").HasColumnName("LAST_MODIFIED");
        }
    }
}
