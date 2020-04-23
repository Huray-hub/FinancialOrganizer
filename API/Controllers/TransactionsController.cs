using Application.Transactions;
using Domain.Entities.Transaction;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class TransactionsController : MediatorBaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> TransactionById(int id) =>
            await Mediator.Send(new TransactionByIdQuery { Id = id });

        public async Transactions
    }
}
