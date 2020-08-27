using Application.Base;
using Domain.Entities.Transaction;

namespace Application.TransactionCategories
{
    public interface ITransactionCategoryUowQuery : IEntityUnitOfWorkQuery<TransactionCategory>
    {
    }
}
