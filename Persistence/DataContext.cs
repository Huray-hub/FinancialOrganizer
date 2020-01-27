using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<AmountModification> AmountModifications { get; set; }
        public DbSet<TransactionAmountModification> TransactionAmountModifications { get; set; }
        public DbSet<AmountModificationCategory> AmountModificationCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Transaction
            //Table Relationships
            builder.Entity<Transaction>()
                .HasKey(pk => pk.Id);

            builder.Entity<Transaction>()
                .HasOne(u => u.User)
                .WithMany(t => t.Transactions)
                .HasForeignKey(ui => ui.UserId)
                .IsRequired();

            builder.Entity<Transaction>()
                .HasOne(tc => tc.Category)
                .WithOne(tc => tc.Transaction)
                .HasForeignKey<Transaction>(t => t.CategoryId);

            //Table types etc
            builder.Entity<Transaction>()
                .Property(t => t.Title)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Transaction>()
                .Property(t => t.Currency)
                .HasColumnType("int")
                .IsRequired();

            builder.Entity<Transaction>()
                .Property(t => t.ExactAmount)
                .HasColumnType("Decimal(10,2)");

            builder.Entity<Transaction>()
                .Property(t => t.MinimumAmount)
                .HasColumnType("Decimal(10,2)");

            builder.Entity<Transaction>()
                .Property(t => t.MaximumAmount)
                .HasColumnType("Decimal(10,2)");

            builder.Entity<Transaction>()
                .Property(t => t.FrequencyRangeStart)
                .HasColumnType("smalldatetime")
                .IsRequired();

            builder.Entity<Transaction>()
                .Property(t => t.FrequencyRangeEnd)
                .HasColumnType("smalldatetime")
                .IsRequired();
            #endregion

            #region TransactionCategory
            builder.Entity<TransactionCategory>()
                .HasKey(tc => tc.Id);

            builder.Entity<TransactionCategory>()
                .Property(tc => tc.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            #endregion

            #region AmountModification
            builder.Entity<AmountModification>()
                .HasKey(pk => pk.Id);

            builder.Entity<AmountModification>()
                .HasOne(am => am.AmountModificationCategory)
                .WithOne(mc => mc.AmountModification)
                .HasForeignKey<AmountModification>(am => am.AmountModificationCategoryId);

            builder.Entity<AmountModification>()
                .Property(am => am.Amount)
                .HasColumnType("Decimal(10,2)")
                .IsRequired();
            #endregion

            #region TransactionAmountModification
            builder.Entity<TransactionAmountModification>()
                .HasKey(ta => new { ta.TransactionId, ta.AmountModificationId });

            builder.Entity<TransactionCategory>()
                .HasKey(pk => pk.Id);
            #endregion

            #region AmountModificationCategory
            builder.Entity<AmountModificationCategory>()
                .HasKey(amc => amc.Id);

            builder.Entity<AmountModificationCategory>()
                .Property(amc => amc.Title)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            #endregion

            #region AppUser
            builder.Entity<AppUser>()
                .Property(u => u.FirstName)
                .HasColumnName("First Name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<AppUser>()
                .Property(u => u.LastName)
                .HasColumnName("Last Name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<AppUser>()
                .Property(u => u.DateOfBirth)
                .HasColumnName("Date Of Birth")
                .HasColumnType("Date")
                .IsRequired();

            builder.Entity<AppUser>()
                .Property(u => u.Country)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<AppUser>()
                .Property(u => u.Email)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<AppUser>()
                .Property(u => u.PasswordHash)
                .IsRequired();
            #endregion
        }
    }
}
