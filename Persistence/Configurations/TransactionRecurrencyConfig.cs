using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TransactionRecurrencyConfig : IEntityTypeConfiguration<TransactionRecurrency>
    {
        public void Configure(EntityTypeBuilder<TransactionRecurrency> builder)
        {
            builder.ToTable("TransactionRecurrencies");

            builder.HasKey(tr => tr.Id);

            builder.Property(tr => tr.HasLimitations).HasColumnType("bit").HasDefaultValue(false).IsRequired();

            builder.Property(tr => tr.FrequencyType).HasColumnName("Frequency Type").IsRequired();

            builder.HasOne(tr => tr.Transaction)
                .WithOne(ta => ta.TransactionRecurrency)
                .HasForeignKey<TransactionRecurrency>(tr => tr.TransactionId)
                .HasConstraintName("FK_TransactionRecurrency_Transaction")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
