using System;

namespace Domain.Entities.Transaction
{
    public class RecurrentTransactionInstallment
    {
        public int RecurrentTransactionInstallmentId { get; set; }
        public int CurrentInstallment { get; set; }
        public DateTime InstallmentTriggerDate { get; set; }

        public int TransactionRecurrencyId { get; set; }

        public TransactionRecurrency TransactionRecurrency { get; set; }


    }
}
