using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionId).IsClustered();

            builder.Property(t => t.TransactionId).HasColumnName("TransactionID");

            builder.Property(t => t.CategoryId).HasColumnName("CategoryID");

            builder.HasOne(t => t.Category)
                .WithMany(tc => tc.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .HasConstraintName("FK_Transactions_Category")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.Title).HasMaxLength(50).IsRequired();

            builder.Property(t => t.Type).IsRequired();

            builder.Property(t => t.Currency).IsRequired();
           
            builder.Property(t => t.Amount).HasColumnType("money").IsRequired();

            builder.Property(t => t.MaxAmount).HasColumnName("Max Amount").HasColumnType("money").IsRequired(false);

            builder.Property(t => t.TriggerDate).HasColumnName("Trigger Date").HasColumnType("smalldatetime").IsRequired();

            builder.Property(t => t.IsRecurrent).HasDefaultValue(false).IsRequired();


            builder.Property(t => t.CreatedByUserId).IsRequired();

            builder.Property(t => t.CreatedAt).HasColumnType("smalldatetime").HasDefaultValue(DateTime.Now).IsRequired();

            builder.Property(t => t.LastModifiedByUserId).IsRequired(false);

            builder.Property(t => t.LastModifiedAt).HasColumnType("smalldatetime").IsRequired(false);
        }
    }
}
