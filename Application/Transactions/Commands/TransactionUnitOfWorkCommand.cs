using Application.Base;
using Application.Common.Adapters;
using Domain.Entities.Transaction;

namespace Application.Transactions.Commands
{
    public class TransactionUnitOfWorkCommand : BaseEntityUnitOfWorkCommand<Transaction>, ITransactionUnitOfWorkCommand
    {
        public TransactionUnitOfWorkCommand(IUnitOfWorkCommand unitOfWork) : base(unitOfWork) { }
    }
}
