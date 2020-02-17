using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class TransactionAmountModificationConfig : IEntityTypeConfiguration<TransactionAmountModification>
    {
        public void Configure(EntityTypeBuilder<TransactionAmountModification> builder)
        {
            builder.HasKey(tam => new { tam.TransactionId, tam.AmountModificationId });

            builder.Property(tam => tam.TransactionId).HasColumnName("TransactionID");

            builder.Property(tam => tam.AmountModificationId).HasColumnName("AmountModificationID");

            builder.HasOne(tam => tam.Transaction)
                .WithMany(t => t.TransactionAmountModifications)
                .HasForeignKey(tam => tam.TransactionId)
                .HasConstraintName("FK_TransactionAmountModifications_Transactions");

            builder.HasOne(tam => tam.AmountModification)
                .WithMany(am => am.TransactionAmountModifications)
                .HasForeignKey(tam => tam.AmountModificationId)
                .HasConstraintName("FK_TransactionAmountModifications_AmountModifications");
        }
    }
}
