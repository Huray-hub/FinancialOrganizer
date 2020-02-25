using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AmountModificationConfig : IEntityTypeConfiguration<AmountModification>
    {
        public void Configure(EntityTypeBuilder<AmountModification> builder)
        {
            builder.Property(am => am.AmountModificationId).HasColumnName("AmountModificationID");

            builder.Property(am => am.AmountModificationCategoryId).HasColumnName("AmountModificationCategoryID");

            builder.HasOne(am => am.AmountModificationCategory)
                .WithMany(amc => amc.AmountModifications)
                .HasForeignKey(am => am.AmountModificationCategoryId)
                .HasConstraintName("FK_AmountModifications_AmountModificationCategory")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(am => am.Amount).HasColumnType("money").IsRequired();

            builder.Property(am => am.AmountType).HasColumnName("Amount Type").IsRequired();

            builder.Property(am => am.AmountCalculationType).HasColumnName("Amount Calculation Type")
                .HasDefaultValue(0).IsRequired();
        }
    }
}
