using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RecurrentTransactionSumAmountModificationConfig : IEntityTypeConfiguration<RecurrentTransactionSumAmountModification>
    {
        public void Configure(EntityTypeBuilder<RecurrentTransactionSumAmountModification> builder)
        {
            builder.ToTable("RecurrentTransactionSumAmountModifications");

            builder.HasKey(rtsam => new { rtsam.RecurrentTransactionLimitationId, rtsam.AmountModificationId });
         
            builder.HasOne(rtsam => rtsam.RecurrentTransactionLimitation)
                .WithMany(rtl => rtl.RecurrentTransactionSumAmountModifications)
                .HasForeignKey(rtsam => rtsam.RecurrentTransactionLimitationId)
                .HasConstraintName("FK_RecurrentTransactionSumAmountModifications_RecurrentTransactionLimitations")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rtsam => rtsam.AmountModification)
                .WithMany(am => am.RecurrentTransactionSumAmountModifications)
                .HasForeignKey(rtsam => rtsam.AmountModificationId)
                .HasConstraintName("FK_RecurrentTransactionSumAmountModifications_AmountModifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
