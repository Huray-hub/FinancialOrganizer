using Application.Common.Exceptions;
using Application.Transactions.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
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

        public EditTransactionHandler(ITransactionUnitOfWorkQuery transactionUnitOfWorkQuery, ITransactionUnitOfWorkCommand transactionUnitOfWorkCommand)
        {
            _transactionUnitOfWorkQuery = transactionUnitOfWorkQuery;
            _transactionUnitOfWorkCommand = transactionUnitOfWorkCommand;
        }

        public async Task<Unit> Handle(EditTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionUnitOfWorkQuery.GetById(request.Id);

            if (transaction == null)            
                throw new RestException(System.Net.HttpStatusCode.NotFound, "Transaction not found");
            
         

            throw new NotImplementedException();
        }
    }
}
