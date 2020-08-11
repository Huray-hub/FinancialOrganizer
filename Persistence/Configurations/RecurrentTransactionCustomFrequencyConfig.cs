using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RecurrentTransactionCustomFrequencyConfig : IEntityTypeConfiguration<RecurrentTransactionCustomFrequency>
    {
        public void Configure(EntityTypeBuilder<RecurrentTransactionCustomFrequency> builder)
        {
            builder.ToTable("RecurrentTransactionCustomFrequencies");

            builder.HasKey(rtcf => rtcf.Id);

            builder.Property(rtcf => rtcf.TimeUnit).HasColumnName("Time Unit").IsRequired();

            builder.Property(rtcf => rtcf.TimeUnitQuantity).HasColumnName("Time Unit Quantity").IsRequired();

            builder.HasOne(rtcf => rtcf.TransactionRecurrency)
                .WithOne(tr => tr.RecurrentTransactionCustomFrequency)
                .HasForeignKey<RecurrentTransactionCustomFrequency>(rtcf => rtcf.TransactionRecurrencyId)
                .HasConstraintName("FK_RecurrentTransactionCustomFrequency_TransactionRecurrency")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
