using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AmountModificationConfig : IEntityTypeConfiguration<AmountModification>
    {
        public void Configure(EntityTypeBuilder<AmountModification> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.HasOne(am => am.AmountModificationCategory).WithOne(mc => mc.AmountModification)
                .HasForeignKey<AmountModification>(am => am.AmountModificationCategoryId);

            builder.Property(am => am.Amount).HasColumnType("Decimal(10,2)").IsRequired();

            builder.Property(am => am.Type).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
