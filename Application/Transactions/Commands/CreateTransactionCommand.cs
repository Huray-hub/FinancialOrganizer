using Application.AmountModifications.Queries;
using Application.Common.Adapters;
using Application.TransactionCategories;
using Domain.Entities.Transaction;
using Domain.Enumerations;
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
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Type).NotEmpty().GreaterThanOrEqualTo(0).LessThan(Enum.GetValues(typeof(TransactionType)).Length);
            RuleFor(x => x.Currency).NotEmpty().GreaterThanOrEqualTo(0).LessThan(Enum.GetValues(typeof(Currency)).Length);
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
            RuleFor(x => x.IsRecurrent).NotEmpty();
            RuleFor(x => x.TransactionRecurrency).NotEmpty().When(x => x.IsRecurrent);
        }
    }

    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand>
    {
        private readonly ITransactionUnitOfWorkCommand _transactionUnitOfWorkCommand;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAmountModificationUowQuery _amountModificationUowQuery;
        private readonly ITransactionCategoryUowQuery _transactionCategoryUowQuery;

        public CreateTransactionHandler(
            ITransactionUnitOfWorkCommand transactionUnitOfWorkCommand,
            ICurrentUserService currentUserService,
            IAmountModificationUowQuery amountModificationUowQuery,
            ITransactionCategoryUowQuery transactionCategoryUowQuery)
        {
            _transactionUnitOfWorkCommand = transactionUnitOfWorkCommand;
            _currentUserService = currentUserService;
            _amountModificationUowQuery = amountModificationUowQuery;
            _transactionCategoryUowQuery = transactionCategoryUowQuery;
        }

        public async Task<Unit> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var category = await _transactionCategoryUowQuery.GetById(request.CategoryId);

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
                LastModifiedAt = null,
                Category = category
            };

            //TODO: When transaction has x amount modifications, common (saved already to db) or not, query to find which are common, 
            //create and save the new ones,  mark them as "not saved from user"?? (?? userId = null ??), and map them with transaction 
            // (TransactionAmountModification)

            //otan o xrhsths paei na kanei modification, epitopou call na ftiaxtei to amountmodification

            if (request.AmountModificationIds != null && request.AmountModificationIds.Any())
            {
                var amountModifications = await _amountModificationUowQuery.GetList(x => request.AmountModificationIds.Contains(x.Id));

                transaction.TransactionAmountModifications = amountModifications.Select(x =>
                    new TransactionAmountModification
                    {
                        AmountModificationId = x.Id
                    }).ToList();
            }

            _transactionUnitOfWorkCommand.Add(transaction);

            var success = await _transactionUnitOfWorkCommand.SaveChanges(cancellationToken) > 0;

            if (success) return Unit.Value;

            throw new Exception("Problem saving changes");
        }
    }
}
