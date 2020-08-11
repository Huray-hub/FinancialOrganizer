using Application.Base;
using Domain.Entities.Transaction;

namespace Application.Transactions.Commands
{
    public interface ITransactionUnitOfWorkCommand : IEntityUnitOfWorkCommand<Transaction> { }
}
