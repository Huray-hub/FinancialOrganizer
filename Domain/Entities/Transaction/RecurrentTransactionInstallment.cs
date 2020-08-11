using System;

namespace Domain.Entities.Transaction
{
    public class RecurrentTransactionInstallment : BaseEntity
    {
        public int CurrentInstallment { get; set; }
        public DateTime InstallmentTriggerDate { get; set; }

        public int TransactionRecurrencyId { get; set; }

        public TransactionRecurrency TransactionRecurrency { get; set; }


    }
}
