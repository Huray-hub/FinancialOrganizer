using Application.Interfaces;
using Application.Transactions.Queries;
using Domain.Entities.Transaction;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Transactions
{
    public class TransactionDetailsQuery : IRequest<Transaction>
    {
        public int Id { get; set; }
    }

    public class GetTransactionDetailsHandler : IRequestHandler<TransactionDetailsQuery, Transaction>
    {
        private readonly ITransactionUnitOfWorkQuery _transactionUnitOfWorkQuery;

        public GetTransactionDetailsHandler(ITransactionUnitOfWorkQuery transactionUnitOfWorkQuery) => 
            _transactionUnitOfWorkQuery = transactionUnitOfWorkQuery;

        public async Task<Transaction> Handle(TransactionDetailsQuery request, CancellationToken cancellationToken) => 
            await _transactionUnitOfWorkQuery.GetById(request.Id);
    }
}
