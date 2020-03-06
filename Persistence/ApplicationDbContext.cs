using Domain;
using Domain.Entities.Transaction;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<TransactionAmount> TransactionAmounts { get; set; }
        public DbSet<TransactionRecurrency> TransactionRecurrencies { get; set; }
        public DbSet<AmountModification> AmountModifications { get; set; }
        public DbSet<TransactionAmountModification> TransactionAmountModifications { get; set; }
        public DbSet<AmountModificationCategory> AmountModificationCategories { get; set; }
        public DbSet<RecurrentTransactionLimitation> RecurrentTransactionLimitations { get; set; }
        public DbSet<RecurrentTransactionSumAmountModification> RecurrentTransactionSumAmountModifications { get; set; }
        public DbSet<RecurrentTransactionInfo> RecurrentTransactionInfo { get; set; }
        public DbSet<RecurrentTransactionCustomFrequency> RecurrentTransactionCustomFrequencies {get; set;}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);         
        }
    }
}
