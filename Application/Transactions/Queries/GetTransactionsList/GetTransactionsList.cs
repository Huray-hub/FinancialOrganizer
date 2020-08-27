using Application.Common.Adapters;
using Application.Common.Exceptions;
using AutoMapper;
using Domain.Entities.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Transactions.Queries.GetTransactionsList
{
    public class TransactionsListQuery : IRequest<List<TransactionDto>>
    {
        public bool IncludeNavigationProperties { get; set; }
    }

    public class GetTransactionsListHandler : IRequestHandler<TransactionsListQuery, List<TransactionDto>>
    {
        private readonly ITransactionUnitOfWorkQuery _transactionUnitOfWorkQuery;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITransactionQueryables _transactionQueryables;
        private readonly IMapper _mapper;

        public GetTransactionsListHandler(
            ITransactionUnitOfWorkQuery transactionUnitOfWorkQuery,
            ICurrentUserService currentUserService,
            ITransactionQueryables transactionQueryables,
            IMapper mapper)
        {
            _transactionUnitOfWorkQuery = transactionUnitOfWorkQuery;
            _currentUserService = currentUserService;
            _transactionQueryables = transactionQueryables;
            _mapper = mapper;
        }

        public async Task<List<TransactionDto>> Handle(TransactionsListQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<Transaction>, IQueryable<Transaction>> includeFunc = null;

            if (request.IncludeNavigationProperties) includeFunc = _transactionQueryables.IncludeNavigationProperties;

            var transactions = await _transactionUnitOfWorkQuery.GetTransactions(_currentUserService.UserId, includeFunc);

            if (transactions.Count == 0)
                throw new RestException(HttpStatusCode.NotFound);

            return _mapper.Map<List<Transaction>, List<TransactionDto>>(transactions);
        }
    }

}
