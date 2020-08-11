using Application.Transactions.Queries;
using Domain.Entities.Transaction;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Transactions
{
    public class TransactionsListQuery : IRequest<List<Transaction>> { }

    public class GetTransactionsListHandler : IRequestHandler<TransactionsListQuery, List<Transaction>>
    {
        private readonly ITransactionUnitOfWorkQuery _transactionUnitOfWorkQuery;

        public GetTransactionsListHandler(ITransactionUnitOfWorkQuery transactionUnitOfWorkQuery) => 
            _transactionUnitOfWorkQuery = transactionUnitOfWorkQuery;

        public async Task<List<Transaction>> Handle(TransactionsListQuery request, CancellationToken cancellationToken) =>
            await _transactionUnitOfWorkQuery.GetList();
    }

}
