using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionId).IsClustered();

            builder.Property(t => t.TransactionId).HasColumnName("TransactionID");

            builder.Property(t => t.UserId).HasColumnName("UserID");

            builder.Property(t => t.CategoryId).HasColumnName("CategoryID");

            builder.HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .IsRequired()
                .HasConstraintName("FK_Transactions_User")
                .OnDelete(DeleteBehavior.Cascade);

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
        }
    }
}
