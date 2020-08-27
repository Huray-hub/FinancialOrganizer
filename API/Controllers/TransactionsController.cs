using Application.Transactions.Commands;
using Application.Transactions.Queries;
using Application.Transactions.Queries.GetTransactionsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TransactionsController : MediatorBaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<TransactionDto>>> List(bool np = false) =>
            await Mediator.Send(new TransactionsListQuery
            {
                IncludeNavigationProperties = np
            });

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> Details(int id, bool np = false) =>
            await Mediator.Send(new TransactionDetailsQuery
            {
                Id = id,
                IncludeNavigationProperties = np
            });

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateTransaction(CreateTransactionCommand command) => await Mediator.Send(command);

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteTransaction(int id) =>
            await Mediator.Send(new DeleteTransactionCommand
            {
                Id = id
            });

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> EditTransaction(int id, EditTransactionCommand command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }
    }
}
