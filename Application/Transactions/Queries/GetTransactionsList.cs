using Application.Common.Adapters;
using Application.Transactions.Queries;
using Domain.Entities.Transaction;
using MediatR;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;

namespace Application.Transactions
{
    public class TransactionsListQuery : IRequest<List<Transaction>> { }

    public class GetTransactionsListHandler : IRequestHandler<TransactionsListQuery, List<Transaction>>
    {
        private readonly ITransactionUnitOfWorkQuery _transactionUnitOfWorkQuery;
        private readonly ICurrentUserService _currentUserService;

        public GetTransactionsListHandler(ITransactionUnitOfWorkQuery transactionUnitOfWorkQuery, ICurrentUserService currentUserService)
        {
            _transactionUnitOfWorkQuery = transactionUnitOfWorkQuery;
            _currentUserService = currentUserService;
        }

        public async Task<List<Transaction>> Handle(TransactionsListQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionUnitOfWorkQuery.GetList(x => x.CreatedByUserId == _currentUserService.UserId);

            if (transactions.Count == 0)
                throw new RestException(HttpStatusCode.NotFound);

            return transactions;
        }
    }

}
