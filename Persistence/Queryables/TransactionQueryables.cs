using Application.Transactions.Queries;
using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Persistence.Queryables
{
    public class TransactionQueryables : ITransactionQueryables
    {
        public IQueryable<Transaction> IncludeNavigationProperties(IQueryable<Transaction> query) =>
           query.Include(x => x.TransactionAmountModifications)
                    .ThenInclude(x => x.AmountModification)
                .Include(x => x.Category)
                .Include(x => x.TransactionRecurrency)
                .ThenInclude(x => x.RecurrentTransactionLimitation)
                .ThenInclude(x => x.RecurrentTransactionSumAmountModifications)
                .ThenInclude(x => x.AmountModification)
                .Include(x => x.TransactionRecurrency)
                    .ThenInclude(x => x.RecurrentTransactionInstallments)
                .Include(x => x.TransactionRecurrency)
                    .ThenInclude(x => x.RecurrentTransactionCustomFrequency);
    }
}
