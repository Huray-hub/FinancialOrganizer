using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Identity
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.DisplayName).HasColumnName("Display Name").HasMaxLength(50).IsRequired();

            builder.Property(u => u.FirstName).HasColumnName("First Name").HasMaxLength(50).IsRequired();

            builder.Property(u => u.LastName).HasColumnName("Last Name").HasMaxLength(50).IsRequired();

            builder.Property(u => u.DateOfBirth).HasColumnName("Date Of Birth").HasColumnType("Date").IsRequired();

            builder.Property(u => u.Country).HasMaxLength(50).IsRequired();

            builder.Property(u => u.Email).HasMaxLength(50).IsRequired();

            builder.Property(u => u.PasswordHash).IsRequired();
        }
    }

}
