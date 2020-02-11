using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FirstName).HasColumnName("First Name").HasColumnType("varchar")
                .HasMaxLength(50).IsRequired();

            builder.Property(u => u.LastName).HasColumnName("Last Name").HasColumnType("varchar")
                .HasMaxLength(50).IsRequired();

            builder.Property(u => u.DateOfBirth).HasColumnName("Date Of Birth").HasColumnType("Date").IsRequired();

            builder.Property(u => u.Country).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.Property(u => u.Email).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.Property(u => u.PasswordHash).IsRequired();
        }
    }
}
