using System;
using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class TransactionRecurrency
    {
        public TransactionRecurrency()
        {
            RecurrentTransactionInfo = new HashSet<RecurrentTransactionInfo>();
        }

        public int TransactionRecurrencyId { get; set; }
        public bool HasLimitations { get; set; }
        public int FrequencyType { get; set; }
      

        public int TransactionAmountId { get; set; }
        public TransactionAmount TransactionAmount { get; set; }

        public RecurrentTransactionLimitation RecurrentTransactionLimitation { get; set; }
        public ICollection<RecurrentTransactionInfo> RecurrentTransactionInfo{ get; private set; }
        public RecurrentTransactionCustomFrequency RecurrentTransactionCustomFrequency { get; set; }
    }
}
