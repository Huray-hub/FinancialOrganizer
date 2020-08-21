using Application.Base;
using Domain.Entities.Transaction;

namespace Application.AmountModifications.Queries
{
    public interface IAmountModificationUowQuery : IEntityUnitOfWorkQuery<AmountModification> { }
}
