using System;
using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class TransactionRecurrency : BaseEntity
    {
        public TransactionRecurrency()
        {
            RecurrentTransactionInstallments = new HashSet<RecurrentTransactionInstallment>();
        }

        public bool HasLimitations { get; set; }
        public int FrequencyType { get; set; }
      
        public int TransactionId { get; set; }

        public Transaction Transaction { get; set; }
        public RecurrentTransactionLimitation RecurrentTransactionLimitation { get; set; }
        public ICollection<RecurrentTransactionInstallment> RecurrentTransactionInstallments { get; private set; }
        public RecurrentTransactionCustomFrequency RecurrentTransactionCustomFrequency { get; set; }
    }
}
