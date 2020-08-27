using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Transaction;
using Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace Application.Transactions.Queries
{
    public class TransactionDto : BaseEntity, IMapFrom<Transaction>
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public int Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime TriggerDate { get; set; }
        public bool IsRecurrent { get; set; }
        public int CategoryId { get; set; }

        public TransactionCategoryDto Category { get; set; }
        public ICollection<TransactionAmountModificationDto> TransactionAmountModifications { get; set; }
        public TransactionRecurrencyDto TransactionRecurrency { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Transaction, TransactionDto>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => (TransactionType)s.Type))
                .ForMember(d => d.Currency, opt => opt.MapFrom(s => (Currency)s.Currency))
                .ForMember(d => d.TransactionAmountModifications, opt => opt.Condition(s => s.TransactionAmountModifications.Count > 0))
                .ForMember(d => d.TransactionRecurrency, opt => opt.Condition(s => s.IsRecurrent));

            profile.CreateMap<TransactionCategory, TransactionCategoryDto>();
            profile.CreateMap<TransactionAmountModification, TransactionAmountModificationDto>();
            profile.CreateMap<TransactionRecurrency, TransactionRecurrencyDto>();
        }
    }

    public class TransactionCategoryDto : BaseEntity, IMapFrom<TransactionCategory>
    {
        public string Name { get; set; }
    }

    public class TransactionAmountModificationDto : IMapFrom<TransactionAmountModification>
    {
        public int TransactionId { get; set; }
        public int AmountModificationId { get; set; }

        public AmountModificationDto AmountModification { get; set; }

        public void Mapping(Profile profile) =>
          profile.CreateMap<AmountModification, AmountModificationDto>();
    }

    public class AmountModificationDto : BaseEntity, IMapFrom<AmountModification>
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string AmountType { get; set; }
        public string AmountCalculationType { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<AmountModification, AmountModificationDto>()
                .ForMember(d => d.AmountType, opt => opt.MapFrom(s => (AmountModificationType)s.AmountType))
                .ForMember(d => d.AmountCalculationType, opt => opt.MapFrom(s => (CalculationType)s.AmountCalculationType));
    }

    public class TransactionRecurrencyDto : BaseEntity, IMapFrom<TransactionRecurrency>
    {
        public bool HasLimitations { get; set; }
        public string FrequencyType { get; set; }

        public int TransactionId { get; set; }

        public RecurrentTransactionLimitationDto RecurrentTransactionLimitation { get; set; }

        public ICollection<RecurrentTransactionInstallmentDto> RecurrentTransactionInstallments { get; private set; }
        public RecurrentTransactionCustomFrequencyDto RecurrentTransactionCustomFrequency { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TransactionRecurrency, TransactionRecurrencyDto>()
                .ForMember(d => d.FrequencyType, opt => opt.MapFrom(s => (TransactionFrequencyType)s.FrequencyType))
                .ForMember(d => d.RecurrentTransactionLimitation, opt => opt.Condition(s => s.HasLimitations))
                .ForMember(d => d.RecurrentTransactionInstallments, opt => opt.MapFrom(s => s.RecurrentTransactionInstallments))
                .ForMember(d => d.RecurrentTransactionCustomFrequency, opt => opt.Condition(s => s.FrequencyType == (int)TransactionFrequencyType.Custom));

            profile.CreateMap<RecurrentTransactionLimitation, RecurrentTransactionLimitationDto>();
            profile.CreateMap<RecurrentTransactionInstallment, RecurrentTransactionInstallmentDto>();
            profile.CreateMap<RecurrentTransactionCustomFrequency, RecurrentTransactionCustomFrequencyDto>();

        }
    }

    public class RecurrentTransactionLimitationDto : BaseEntity, IMapFrom<RecurrentTransactionLimitation>
    {
        public int SumInstallments { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SumAmount { get; set; }
        public decimal? MaxSumAmount { get; set; }

        public int TransactionRecurrencyId { get; set; }

        public ICollection<RecurrentTransactionSumAmountModification> RecurrentTransactionSumAmountModifications { get; private set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<RecurrentTransactionSumAmountModification, RecurrentTransactionSumAmountModificationDto>();
    }

    public class RecurrentTransactionInstallmentDto : BaseEntity, IMapFrom<RecurrentTransactionInstallment>
    {
        public int CurrentInstallment { get; set; }
        public DateTime InstallmentTriggerDate { get; set; }

        public int TransactionRecurrencyId { get; set; }
    }

    public class RecurrentTransactionCustomFrequencyDto : BaseEntity, IMapFrom<RecurrentTransactionCustomFrequency>
    {
        public int TimeUnit { get; set; }
        public int TimeUnitQuantity { get; set; }

        public int TransactionRecurrencyId { get; set; }
    }

    public class RecurrentTransactionSumAmountModificationDto : IMapFrom<RecurrentTransactionSumAmountModification>
    {
        public int RecurrentTransactionLimitationId { get; set; }
        public int AmountModificationId { get; set; }

        public AmountModificationDto AmountModification { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<AmountModification, AmountModificationDto>();
    }
}
