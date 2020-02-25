using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TransactionAmountConfig : IEntityTypeConfiguration<TransactionAmount>
    {
        public void Configure(EntityTypeBuilder<TransactionAmount> builder)
        {
            builder.Property(ta => ta.TransactionAmountId).HasColumnName("TransactionAmountID");

            builder.Property(ta => ta.Amount).HasColumnType("money").IsRequired();

            builder.Property(ta => ta.MaxAmount).HasColumnType("money").IsRequired();

            builder.Property(ta => ta.TriggerDate).HasColumnName("Trigger Date").HasColumnType("smalldatetime").IsRequired();

            builder.HasOne(ta => ta.Transaction)
                .WithOne(t => t.TransactionAmount)
                .HasForeignKey<TransactionAmount>(ta => ta.TransactionId)
                .HasConstraintName("FK_TransactionAmounts_Transactions")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
