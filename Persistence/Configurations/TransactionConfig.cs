using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(t => t.TransactionId).HasColumnName("TransactionID");

            builder.Property(t => t.UserId).HasColumnName("UserID");

            builder.Property(t => t.CategoryId).HasColumnName("CategoryID");

            builder.HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .IsRequired()
                .HasConstraintName("FK_Transactions_User");

            builder.HasOne(t => t.Category)
                .WithMany(tc => tc.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .HasConstraintName("FK_Transactions_Category");

            builder.Property(t => t.Title).HasMaxLength(50).IsRequired();

            builder.Property(t => t.Type).IsRequired();

            builder.Property(t => t.Currency).IsRequired();

            builder.Property(t => t.ExactAmount).HasColumnName("Exact Amount").HasColumnType("money")
                .HasDefaultValue(null);

            builder.Property(t => t.MinimumAmount).HasColumnName("Minimum Amount").HasColumnType("money")
                .HasDefaultValue(null);

            builder.Property(t => t.MaximumAmount).HasColumnName("Maximum Amount").HasColumnType("money")
                .HasDefaultValue(null);

            builder.Property(t => t.FrequencyRangeStart).HasColumnName("Frequency Range Start")
                .HasColumnType("smalldatetime").IsRequired();

            builder.Property(t => t.FrequencyRangeEnd).HasColumnName("Frequency Range End")
                .HasColumnType("smalldatetime").IsRequired();
        }
    }
}
