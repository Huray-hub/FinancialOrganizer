using Application.Base;
using Domain.Entities.Transaction;

namespace Application.AmountModifications.Commands
{
    public interface IAmountModificationUowCommand : IEntityUnitOfWorkCommand<AmountModification>
    {
    }
}
