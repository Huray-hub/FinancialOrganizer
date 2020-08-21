
using Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class Transaction : AuditedEntity
    {
        public Transaction()
        {
            TransactionAmountModifications = new HashSet<TransactionAmountModification>();
        }

        public string Title { get; set; }
        public int Type { get; set; }
        public int Currency { get; set; }      
        public decimal Amount { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime TriggerDate { get; set; }
        public bool IsRecurrent { get; set; }

        //public string UserId { get; set; }       
        public int CategoryId { get; set; }

        //public ApplicationUser User { get; set; }
        public TransactionCategory Category { get; set; }
        public ICollection<TransactionAmountModification> TransactionAmountModifications { get;  set; }
        public TransactionRecurrency TransactionRecurrency { get; set; }    
    }
}
