using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TransactionCategoryConfig : IEntityTypeConfiguration<TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder.Property(tc => tc.TransactionCategoryId).HasColumnName("TransactionCategoryID");
           
            builder.Property(tc => tc.Name).HasMaxLength(50).IsRequired();
        }
    }
}
