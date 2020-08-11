using Application.Transactions;
using Application.Transactions.Commands;
using Domain.Entities.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TransactionsController : MediatorBaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetTransactions() => await Mediator.Send(new TransactionsListQuery());

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int id) => await Mediator.Send(new TransactionDetailsQuery { Id = id });

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateTransaction(CreateTransactionCommand command) => await Mediator.Send(command);
    }
}
