using Application.Base;
using Domain.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Transactions.Queries
{
    public interface ITransactionUnitOfWorkQuery : IEntityUnitOfWorkQuery<Transaction>
    {

        Task<Transaction> GetTransaction(int transactionId, string userId, Func<IQueryable<Transaction>, IQueryable<Transaction>> includeFunc = null);

        Task<List<Transaction>> GetTransactions(string userId, Func<IQueryable<Transaction>, IQueryable<Transaction>> includeFunc = null);
    }
}
