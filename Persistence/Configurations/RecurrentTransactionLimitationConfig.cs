using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RecurrentTransactionLimitationConfig : IEntityTypeConfiguration<RecurrentTransactionLimitation>
    {
        public void Configure(EntityTypeBuilder<RecurrentTransactionLimitation> builder)
        {
            builder.ToTable("RecurrentTransactionLimitations");

            builder.HasKey(rtl => rtl.Id);

            builder.Property(rtl => rtl.SumInstallments).HasColumnName("Sum Installments").IsRequired();

            builder.Property(rtl => rtl.EndDate).HasColumnName("End Date").HasColumnType("smalldatetime").IsRequired();

            builder.Property(rtl => rtl.SumAmount).HasColumnName("Sum Amount").IsRequired();

            builder.Property(rtl => rtl.MaxSumAmount).HasColumnName("Max Sum Amount").IsRequired(false);

            builder.HasOne(rtl => rtl.TransactionRecurrency)
                .WithOne(tr => tr.RecurrentTransactionLimitation)
                .HasForeignKey<RecurrentTransactionLimitation>(rtl => rtl.TransactionRecurrencyId)
                .HasConstraintName("FK_RecurrentTransactionLimitation_TransactionRecurrency")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
