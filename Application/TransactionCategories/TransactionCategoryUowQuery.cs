using Application.Base;
using Application.Common.Adapters;
using Domain.Entities.Transaction;

namespace Application.TransactionCategories
{
    public class TransactionCategoryUowQuery : BaseEntityUnitOfWorkQuery<TransactionCategory>, ITransactionCategoryUowQuery
    {
        public TransactionCategoryUowQuery(IUnitOfWorkQuery unitOfWork) : base(unitOfWork) { }
    }
}
