using Application.Base;
using Application.Common.Adapters;
using Domain.Entities.Transaction;

namespace Application.AmountModifications.Commands
{
    public class AmountModificationUowCommand : BaseEntityUnitOfWorkCommand<AmountModification>, IAmountModificationUowCommand
    {
        public AmountModificationUowCommand(IUnitOfWorkCommand unitOfWork) : base(unitOfWork)
        {
        }
    }
}
