using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RecurrentTransactionIstallmentConfig : IEntityTypeConfiguration<RecurrentTransactionInstallment>
    {
        public void Configure(EntityTypeBuilder<RecurrentTransactionInstallment> builder)
        {
            builder.Property(rti => rti.RecurrentTransactionInstallmentId).HasColumnName("RecurrentTransactionInstallmentID");

            builder.Property(rti => rti.CurrentInstallment).HasColumnName("Current Installment").IsRequired();

            builder.Property(rti => rti.InstallmentTriggerDate).HasColumnName("Installment Trigger Date").HasColumnType("smalldatetime").IsRequired();

            builder.HasOne(rti => rti.TransactionRecurrency)
                .WithMany(tr => tr.RecurrentTransactionInstallments)
                .HasForeignKey(rti => rti.TransactionRecurrencyId)
                .HasConstraintName("FK_RecurrentTransactionInstallments_TransactionRecurrency");
        }
    }
}
