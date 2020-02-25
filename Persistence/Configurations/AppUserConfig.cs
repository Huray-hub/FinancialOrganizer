using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FirstName).HasColumnName("First Name").HasMaxLength(50).IsRequired();

            builder.Property(u => u.LastName).HasColumnName("Last Name").HasMaxLength(50).IsRequired();

            builder.Property(u => u.DateOfBirth).HasColumnName("Date Of Birth").HasColumnType("Date").IsRequired();

            builder.Property(u => u.Country).HasMaxLength(50).IsRequired();

            builder.Property(u => u.Email).HasMaxLength(50).IsRequired();

            builder.Property(u => u.PasswordHash).IsRequired();
        }
    }
}
