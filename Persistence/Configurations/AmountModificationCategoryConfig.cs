using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AmountModificationCategoryConfig : IEntityTypeConfiguration<AmountModificationCategory>
    {
        public void Configure(EntityTypeBuilder<AmountModificationCategory> builder)
        {
            builder.Property(amc => amc.AmountModificationCategoryId).HasColumnName("AmountModificationCategoryID");

            builder.Property(amc => amc.Title).HasMaxLength(50).IsRequired();         
        }
    }
}
