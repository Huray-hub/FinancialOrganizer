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

            builder.Property(tr => tr.Installment).HasColumnType("money").IsRequired();

            builder.Property(tr => tr.InstallmentsNumber).HasColumnName("Installments Number").IsRequired();

            builder.Property(tr => tr.FrequencyType).HasColumnName("Frequency Type").IsRequired();

            builder.Property(tr => tr.EndDate).HasColumnName("End Date").HasColumnType("smalldatetime");

            builder.HasOne(tr => tr.TransactionAmount)
                .WithOne(ta => ta.TransactionRecurrency)
                .HasForeignKey<TransactionRecurrency>(tr => tr.TransactionRecurrencyId)
                .HasConstraintName("FK_TransactionRecurrencies_TransactionAmounts")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
