using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TransactionRecurrencyConfig : IEntityTypeConfiguration<TransactionRecurrency>
    {
        public void Configure(EntityTypeBuilder<TransactionRecurrency> builder)
        {
            builder.Property(tr => tr.TransactionRecurrencyId).HasColumnName("TransactionRecurrencyID");

            builder.Property(tr => tr.HasLimitations).HasColumnType("bit").HasDefaultValue(false).IsRequired();

            builder.Property(tr => tr.FrequencyType).HasColumnName("Frequency Type").IsRequired();

            builder.HasOne(tr => tr.TransactionAmount)
                .WithOne(ta => ta.TransactionRecurrency)
                .HasForeignKey<TransactionRecurrency>(tr => tr.TransactionAmountId)
                .HasConstraintName("FK_TransactionRecurrency_TransactionAmount")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
