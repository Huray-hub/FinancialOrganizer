using Application.Interfaces;
using Domain.Entities.Transaction;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Transactions.Commands
{
    public class CreateTransactionCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int Currency { get; set; }
        public int TransactionAmountId { get; set; }
        public decimal Amount { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime TriggerDate { get; set; }
        public bool IsRecurrent { get; set; }
        public int CategoryId { get; set; }
        public object[] TransactionAmountModifications { get; set; }
        public object TransactionRecurrency { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastModifiedByUserId { get; set; }
        public string LastModifiedAt { get; set; }
    }

    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand>
    {
        private readonly ITransactionUnitOfWorkCommand _transactionUnitOfWorkCommand;

        public CreateTransactionHandler(ITransactionUnitOfWorkCommand transactionUnitOfWorkCommand) => 
            _transactionUnitOfWorkCommand = transactionUnitOfWorkCommand;

        public Task<Unit> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
