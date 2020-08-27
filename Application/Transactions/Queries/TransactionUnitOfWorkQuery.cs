using Application.Base;
using Application.Common.Adapters;
using Domain.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Transactions.Queries
{
    public class TransactionUnitOfWorkQuery : BaseEntityUnitOfWorkQuery<Transaction>, ITransactionUnitOfWorkQuery
    {
        public TransactionUnitOfWorkQuery(IUnitOfWorkQuery unitOfWork) : base(unitOfWork) { }

        public async Task<Transaction> GetTransaction(int transactionId, string userId, Func<IQueryable<Transaction>, IQueryable<Transaction>> includeFunc = null) =>
            await GetById(transactionId, x => x.CreatedByUserId == userId, includeFunc);

        public async Task<List<Transaction>> GetTransactions(string userId, Func<IQueryable<Transaction>, IQueryable<Transaction>> includeFunc = null) =>
            await GetList(x => x.CreatedByUserId == userId, includeFunc);
    }
}
