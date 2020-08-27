using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AmountModificationConfig : IEntityTypeConfiguration<AmountModification>
    {
        public void Configure(EntityTypeBuilder<AmountModification> builder)
        {
            builder.ToTable("AmountModifications");

            builder.HasKey(am => am.Id);

            builder.Property(am => am.Title).HasMaxLength(50).IsRequired();

            builder.Property(am => am.Amount).HasColumnType("money").IsRequired();

            builder.Property(am => am.AmountType).HasColumnName("Amount Type").IsRequired();

            builder.Property(am => am.AmountCalculationType).HasColumnName("Amount Calculation Type")
                .HasDefaultValue(0).IsRequired();
        }
    }
}
