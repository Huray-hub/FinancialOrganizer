using System;
using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class TransactionAmount
    {
        public Guid TransactionAmountId { get; set; }
        public decimal Amount { get; set; }
        public decimal MaxAmount { get; set; }
        public DateTime TriggerDate { get; set; }

        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public IList<TransactionAmountModification> TransactionAmountModifications { get; set; }
      
        public TransactionRecurrency TransactionRecurrency { get; set; }      
    }
}
