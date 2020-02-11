using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            //Table Relationships
            builder.HasKey(pk => pk.Id);

            builder.HasOne(u => u.User).WithMany(t => t.Transactions).HasForeignKey(ui => ui.UserId).IsRequired();

            builder.HasOne(tc => tc.Category).WithOne(tc => tc.Transaction).HasForeignKey<Transaction>(t => t.CategoryId);

            //Table types etc
            builder.Property(t => t.Title).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.Property(t => t.Type).HasColumnType("varchar(50)").IsRequired();

            builder.Property(t => t.Currency).HasColumnType("varchar(50)").IsRequired();

            builder.Property(t => t.ExactAmount).HasColumnType("Decimal(10,2)");

            builder.Property(t => t.MinimumAmount).HasColumnType("Decimal(10,2)");

            builder.Property(t => t.MaximumAmount).HasColumnType("Decimal(10,2)");

            builder.Property(t => t.FrequencyRangeStart).HasColumnType("smalldatetime").IsRequired();

            builder.Property(t => t.FrequencyRangeEnd).HasColumnType("smalldatetime").IsRequired();
        }
    }
}
