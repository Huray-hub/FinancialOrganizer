using Application.Interfaces;
using Domain.Entities.Transaction;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Transactions
{
    public class TransactionByIdQuery : IRequest<Transaction>
    {
        public int Id { get; set; }
    }

    public class GetTransactionByIdHandler : IRequestHandler<TransactionByIdQuery, Transaction>
    {
        private readonly IRepository<Transaction> _transactionRepository;


        public GetTransactionByIdHandler(IRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Task<Transaction> Handle(TransactionByIdQuery request, CancellationToken cancellationToken)
        {
            return  _transactionRepository.GetById(request.Id);
        }
    }
}
