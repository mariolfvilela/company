using System;
using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Infra.Data.Mappings
{
    internal class UserMap : MapBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("User");
            builder.Property(c => c.Username).IsRequired().HasColumnName("Username").HasColumnType("varchar(150)").HasMaxLength(150);
            builder.Property(c => c.Password).IsRequired().HasColumnName("Password").HasColumnType("varchar(150)").HasMaxLength(150);
            builder.Property(c => c.Roles).IsRequired().HasColumnName("Roles");
        }
    }
}
