using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AmountModificationCategoryConfig : IEntityTypeConfiguration<AmountModificationCategory>
    {
        public void Configure(EntityTypeBuilder<AmountModificationCategory> builder)
        {
            builder.HasKey(amc => amc.Id);

            builder.Property(amc => amc.Title).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        }
    }
}
