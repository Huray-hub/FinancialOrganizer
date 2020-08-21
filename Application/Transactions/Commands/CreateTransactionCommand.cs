using Application.AmountModifications.Queries;
using Application.Common.Adapters;
using Domain.Entities.Transaction;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Transactions.Commands
{
    public class CreateTransactionCommand : IRequest
    {
        public string Title { get; set; }
        public int Type { get; set; }
        public int Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime? TriggerDate { get; set; }
        public bool IsRecurrent { get; set; }
        public int CategoryId { get; set; }
        public List<int> AmountModificationIds { get; set; }
        public TransactionRecurrency TransactionRecurrency { get; set; }
    }

    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Currency).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.MaxAmount).NotEmpty();
        }
    }

    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand>
    {
        private readonly ITransactionUnitOfWorkCommand _transactionUnitOfWorkCommand;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAmountModificationUowQuery _amountModificationUowQuery;


        public CreateTransactionHandler(
            ITransactionUnitOfWorkCommand transactionUnitOfWorkCommand,
            ICurrentUserService currentUserService,
            IAmountModificationUowQuery amountModificationUowQuery)
        {
            _transactionUnitOfWorkCommand = transactionUnitOfWorkCommand;
            _currentUserService = currentUserService;
            _amountModificationUowQuery = amountModificationUowQuery;
        }

        public async Task<Unit> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                Title = request.Title,
                Type = request.Type,
                Currency = request.Currency,
                Amount = request.Amount,
                MaxAmount = request.MaxAmount,
                TriggerDate = request.TriggerDate ?? DateTime.Now,
                IsRecurrent = request.IsRecurrent,
                CategoryId = request.CategoryId,
                TransactionRecurrency = request.IsRecurrent ? request.TransactionRecurrency : null,
                CreatedByUserId = _currentUserService.UserId,
                CreatedAt = DateTime.Now,
                LastModifiedByUserId = null,
                LastModifiedAt = null
            };

            //TODO: Thelw otan an to transaction exei upostei x tropopoihseis, koines (kataxwrimenes) i oxi, na kanw query wste na vrw poies einai 
            //koines, na kataxwrisw tis agnwstes me kapoio tropo pou na markarontai ws "mh swsmenes apo to xrhsth" (?? userId = null ??), kai na 
            //kataxwrisw gia oles TransactionAmountModification

            //otan o xrhsths paei na kanei modification, epitopou call na ftiaxtei to amountmodification

            if (request.AmountModificationIds.Any())
            {
                var amountModifications = await _amountModificationUowQuery.GetList(x => request.AmountModificationIds.Contains(x.Id));

                transaction.TransactionAmountModifications = amountModifications.Select(x =>
                    new TransactionAmountModification
                    {
                        AmountModificationId = x.Id
                    }).ToList();
            }

            _transactionUnitOfWorkCommand.Add(transaction);

            var success = await _transactionUnitOfWorkCommand.SaveChanges() > 0;

            if (success) return Unit.Value;

            throw new Exception("Problem saving changes");
        }
    }
}
