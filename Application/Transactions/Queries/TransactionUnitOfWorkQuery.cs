using Application.Base;
using Application.Common.Adapters;
using Domain.Entities.Transaction;

namespace Application.Transactions.Queries
{
    public class TransactionUnitOfWorkQuery : BaseEntityUnitOfWorkQuery<Transaction>, ITransactionUnitOfWorkQuery
    {
        public TransactionUnitOfWorkQuery(IUnitOfWorkQuery unitOfWork) : base(unitOfWork) { }
    }
}
