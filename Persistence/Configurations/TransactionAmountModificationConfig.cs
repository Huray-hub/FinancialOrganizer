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
            builder.HasKey(ta => new { ta.TransactionId, ta.AmountModificationId });

            builder.HasOne(t => t.Transaction).WithMany(tam => tam.TransactionAmountModifications)
                .HasForeignKey(t => t.TransactionId);

            builder.HasOne(am => am.AmountModification).WithMany(tam => tam.TransactionAmountModifications)
                .HasForeignKey(am => am.AmountModificationId);
        }
    }
}
