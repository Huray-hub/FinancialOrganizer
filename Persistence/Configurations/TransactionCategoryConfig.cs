using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TransactionCategoryConfig : IEntityTypeConfiguration<TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.Name).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
        }
    }
}
