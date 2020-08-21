using Application.Common.Adapters;
using Domain.Entities.Transaction;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;

namespace Application.Transactions.Queries
{
    public class TransactionDetailsQuery : IRequest<Transaction>
    {
        public int Id { get; set; }
    }

    public class GetTransactionDetailsHandler : IRequestHandler<TransactionDetailsQuery, Transaction>
    {
        private readonly ITransactionUnitOfWorkQuery _transactionUnitOfWorkQuery;
        private readonly ICurrentUserService _currentUserService;

        public GetTransactionDetailsHandler(ITransactionUnitOfWorkQuery transactionUnitOfWorkQuery, ICurrentUserService currentUserService)
        {
            _transactionUnitOfWorkQuery = transactionUnitOfWorkQuery;
            _currentUserService = currentUserService;
        }

        public async Task<Transaction> Handle(TransactionDetailsQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionUnitOfWorkQuery.GetById(request.Id);

            if (transaction == null || transaction.CreatedByUserId != _currentUserService.UserId)
                throw new RestException(HttpStatusCode.NotFound, "transaction not found");

            return transaction;
        }
    }
}
