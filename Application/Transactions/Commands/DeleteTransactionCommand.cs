using Application.Common.Adapters;
using Application.Transactions.Queries;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;

namespace Application.Transactions.Commands
{
    public class DeleteTransactionCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTransactionHandler : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionUnitOfWorkCommand _transactionUnitOfWorkCommand;
        private readonly ITransactionUnitOfWorkQuery _transactionUnitOfWorkQuery;
        private readonly ICurrentUserService _currentUserService;

        public DeleteTransactionHandler(ITransactionUnitOfWorkCommand transactionUnitOfWorkCommand, 
            ITransactionUnitOfWorkQuery transactionUnitOfWorkQuery, ICurrentUserService currentUserService)
        {
            _transactionUnitOfWorkCommand = transactionUnitOfWorkCommand;
            _transactionUnitOfWorkQuery = transactionUnitOfWorkQuery;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionUnitOfWorkQuery.GetById(request.Id);

            if (transaction.CreatedByUserId != _currentUserService.UserId)            
                throw new RestException(HttpStatusCode.Unauthorized);
            

            if (transaction == null)
                throw new RestException(HttpStatusCode.NotFound, "transaction not found");

            _transactionUnitOfWorkCommand.Remove(transaction);

            var success = await _transactionUnitOfWorkCommand.SaveChanges() > 0;

            if (success) return Unit.Value;

            throw new Exception();
        }
    }
}
