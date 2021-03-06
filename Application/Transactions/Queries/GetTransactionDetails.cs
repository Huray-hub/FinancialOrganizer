﻿using Application.Common.Adapters;
using Application.Common.Exceptions;
using AutoMapper;
using Domain.Entities.Transaction;
using MediatR;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Transactions.Queries
{
    public class TransactionDetailsQuery : IRequest<TransactionDto>
    {
        public int Id { get; set; }
        public bool IncludeNavigationProperties { get; set; }
    }

    public class GetTransactionDetailsHandler : IRequestHandler<TransactionDetailsQuery, TransactionDto>
    {
        private readonly ITransactionUnitOfWorkQuery _transactionUnitOfWorkQuery;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITransactionQueryables _transactionQueryables;
        private readonly IMapper _mapper;

        public GetTransactionDetailsHandler(
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

        public async Task<TransactionDto> Handle(TransactionDetailsQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<Transaction>, IQueryable<Transaction>> includeFunc = null;

            if (request.IncludeNavigationProperties) includeFunc = _transactionQueryables.IncludeNavigationProperties;

            var transaction = await _transactionUnitOfWorkQuery.GetTransaction(request.Id, _currentUserService.UserId, includeFunc);

            if (transaction == null)
                throw new RestException(HttpStatusCode.NotFound, "transaction not found");

            return _mapper.Map<Transaction, TransactionDto>(transaction);
        }
    }
}
