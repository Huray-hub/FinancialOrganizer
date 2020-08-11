using Application.Base;
using Domain.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transactions.Queries
{
    public interface ITransactionUnitOfWorkQuery : IEntityUnitOfWorkQuery<Transaction> { }
}
