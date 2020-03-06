using System;
using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class TransactionAmount
    {
        public TransactionAmount()
        {
            TransactionAmountModifications = new HashSet<TransactionAmountModification>();
        }

        public int TransactionAmountId { get; set; }
        public decimal Amount { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime TriggerDate { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public ICollection<TransactionAmountModification> TransactionAmountModifications { get; private set; }    
        public TransactionRecurrency TransactionRecurrency { get; set; }      
    }
}
