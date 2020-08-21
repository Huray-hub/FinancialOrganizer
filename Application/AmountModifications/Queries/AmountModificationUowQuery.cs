using Application.Base;
using Application.Common.Adapters;
using Domain.Entities.Transaction;

namespace Application.AmountModifications.Queries
{
    public class AmountModificationUowQuery : BaseEntityUnitOfWorkQuery<AmountModification>, IAmountModificationUowQuery
    {
        public AmountModificationUowQuery(IUnitOfWorkQuery unitOfWork) : base(unitOfWork) { }
    }
}
