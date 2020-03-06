using System;

namespace Domain.Entities.Transaction
{
    public class RecurrentTransactionInfo
    {
        public int RecurrentTransactionInfoId { get; set; }
        public int CurrentTransaction { get; set; }
        public DateTime CurrentTriggerDate { get; set; }


        public int TransactionRecurrencyId { get; set; }
        public TransactionRecurrency TransactionRecurrency { get; set; }


    }
}
