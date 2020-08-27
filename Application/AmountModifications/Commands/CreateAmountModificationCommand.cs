using Domain.Entities.Transaction;
using Domain.Enumerations;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AmountModifications.Commands
{
    public class CreateAmountModificationCommand : IRequest
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public int AmountType { get; set; }
        public int AmountCalculationType { get; set; }
    }

    public class CreateAmountModificationCommandValidator : AbstractValidator<CreateAmountModificationCommand>
    {
        public CreateAmountModificationCommandValidator()
        {
            RuleFor(x => x.AmountCalculationType).GreaterThanOrEqualTo(0).LessThan((int)CalculationType.Percentage);
        }
    }

    public class CreateAmountModificationHandler : IRequestHandler<CreateAmountModificationCommand>
    {
        private readonly IAmountModificationUowCommand _amountModificationUowCommand;

        public CreateAmountModificationHandler(IAmountModificationUowCommand amountModificationUowCommand)
        {
            _amountModificationUowCommand = amountModificationUowCommand;
        }

        public async Task<Unit> Handle(CreateAmountModificationCommand request, CancellationToken cancellationToken)
        {
            var amounModification = new AmountModification
            {
                Title = request.Title,
                Amount = request.Amount,
                AmountType = request.AmountType,
                AmountCalculationType = request.AmountCalculationType
            };

            _amountModificationUowCommand.Add(amounModification);

            var success = await _amountModificationUowCommand.SaveChanges(cancellationToken) > 0;

            if (success) return Unit.Value;

            throw new Exception("Problem saving changes");
        }
    }
}
