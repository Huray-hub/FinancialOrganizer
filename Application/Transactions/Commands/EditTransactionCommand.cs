using Application.Common.Adapters;
using Application.Common.Exceptions;
using Application.Transactions.Queries;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Transactions.Commands
{
    public class EditTransactionCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class EditTransactionHandler : IRequestHandler<EditTransactionCommand>
    {
        private readonly ITransactionUnitOfWorkQuery _transactionUnitOfWorkQuery;
        private readonly ITransactionUnitOfWorkCommand _transactionUnitOfWorkCommand;
        private readonly ICurrentUserService _currentUserService;

        public EditTransactionHandler(
            ITransactionUnitOfWorkQuery transactionUnitOfWorkQuery,
            ITransactionUnitOfWorkCommand transactionUnitOfWorkCommand,
            ICurrentUserService currentUserService)
        {
            _transactionUnitOfWorkQuery = transactionUnitOfWorkQuery;
            _transactionUnitOfWorkCommand = transactionUnitOfWorkCommand;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(EditTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionUnitOfWorkQuery.GetTransaction(request.Id, _currentUserService.UserId);

            if (transaction == null)
                throw new RestException(HttpStatusCode.NotFound, "Transaction not found");

            //TODO: Need to decide which parts of the transaction shut actually be editable
            



            throw new NotImplementedException();
        }
    }
}
