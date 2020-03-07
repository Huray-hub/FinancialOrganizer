﻿using System;
using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class Transaction
    {
        public Transaction()
        {
            TransactionAmountModifications = new HashSet<TransactionAmountModification>();
        }

        public int TransactionId { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int Currency { get; set; }
        public int TransactionAmountId { get; set; }
        public decimal Amount { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime TriggerDate { get; set; }
        public bool IsRecurrent { get; set; }

        public string UserId { get; set; }       
        public int CategoryId { get; set; }

        public AppUser User { get; set; }
        public TransactionCategory Category { get; set; }
        public ICollection<TransactionAmountModification> TransactionAmountModifications { get; private set; }
        public TransactionRecurrency TransactionRecurrency { get; set; }    
    }
}
