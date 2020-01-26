using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext: IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<AmountModification> AmountModifications { get; set; }
        public DbSet<TransactionAmountModification>  TransactionAmountModifications { get; set; }
        public DbSet<AmountModificationCategory> ModificationCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Transaction
            builder.Entity<Transaction>()
                .HasKey(pk => pk.Id);

            builder.Entity<Transaction>()
                .HasOne(u => u.User)
                .WithMany(t => t.Transactions)
                .HasForeignKey(ui => ui.UserId);

            builder.Entity<Transaction>()
                .HasOne(tc => tc.Category)
                .WithOne(tc => tc.Transaction)
                .HasForeignKey<Transaction>(t => t.CategoryId);
            #endregion

            #region AmountModification
            builder.Entity<AmountModification>()
                .HasKey(pk => pk.Id);

            builder.Entity<AmountModification>()
                .HasOne(am => am.AmountModificationCategory)
                .WithOne(mc => mc.AmountModification)
                .HasForeignKey<AmountModification>(am => am.AmountModificationCategoryId);
            #endregion

            #region TransactionAmountModification
            builder.Entity<TransactionAmountModification>()
                .HasKey(ta => new { ta.TransactionId, ta.AmountModificationId });

            builder.Entity<TransactionCategory>()
                .HasKey(pk => pk.Id);
            #endregion



            builder.Entity<AppUser>()
                .Property(u => u.FirstName)
                .HasColumnName("First Name")
                .HasColumnType("string")           
                .IsRequired();

            builder.Entity<AppUser>()
                .Property(u => u.LastName)
                .HasColumnName("Last Name")
                .HasColumnType("string")
                .IsRequired();

            builder.Entity<AppUser>()
                .Property(u => u.DateOfBirth)
                .HasColumnName("Date Of Birth")
                .HasColumnType("Date")
                .IsRequired();

            builder.Entity<AppUser>()
                .Property(u => u.Country)
                .HasColumnType("string")
                .IsRequired();
                
        }
    }
}
