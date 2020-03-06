using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RecurrentTransactionInfoConfig : IEntityTypeConfiguration<RecurrentTransactionInfo>
    {
        public void Configure(EntityTypeBuilder<RecurrentTransactionInfo> builder)
        {
            builder.Property(rti => rti.RecurrentTransactionInfoId).HasColumnName("RecurrentTransactionInfoID");

            builder.Property(rti => rti.CurrentTransaction).IsRequired();

            builder.Property(rti => rti.CurrentTriggerDate).IsRequired();

            builder.HasOne(rti => rti.TransactionRecurrency)
                .WithMany(tr => tr.RecurrentTransactionInfo)
                .HasForeignKey(rti => rti.TransactionRecurrencyId)
                .HasConstraintName("FK_RecurrentTransactionInfo_TransactionRecurrency");
        }
    }
}
