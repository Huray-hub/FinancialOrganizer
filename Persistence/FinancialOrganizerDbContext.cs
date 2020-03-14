using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class FinancialOrganizerDbContext : DbContext
    {
        public FinancialOrganizerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<TransactionRecurrency> TransactionRecurrencies { get; set; }
        public DbSet<AmountModification> AmountModifications { get; set; }
        public DbSet<TransactionAmountModification> TransactionAmountModifications { get; set; }     
        public DbSet<RecurrentTransactionLimitation> RecurrentTransactionLimitations { get; set; }
        public DbSet<RecurrentTransactionSumAmountModification> RecurrentTransactionSumAmountModifications { get; set; }
        public DbSet<RecurrentTransactionInstallment> RecurrentTransactionInstallments { get; set; }
        public DbSet<RecurrentTransactionCustomFrequency> RecurrentTransactionCustomFrequencies {get; set;}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries<AuditedEntity>())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedBy = _currentUserService.UserId;
        //                entry.Entity.CreatedAt = _dateTime.Now;
        //                break;
        //            case EntityState.Modified:
        //                entry.Entity.LastModifiedBy = _currentUserService.UserId;
        //                entry.Entity.LastModifiedAt = _dateTime.Now;
        //                break;
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(FinancialOrganizerDbContext).Assembly);

            base.OnModelCreating(builder);         
        }
    }
}
