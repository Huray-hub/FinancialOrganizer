using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{  
    public class Transaction
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public CurrencyType Currency { get; set; }

        public decimal ExactAmount { get; set; }

        public decimal MinimumAmount { get; set; }

        public decimal MaximumAmount { get; set; }

        public DateTime FrequencyRangeStart { get; set; }

        public DateTime FrequencyRangeEnd { get; set; }


        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Guid CategoryId { get; set; }
        public TransactionCategory Category { get; set; }

        public IList<TransactionAmountModification> TransactionAmountModifications { get; set; }
    }

    public enum Type
    {
        Revenue,
        Expense
    }

    public enum CurrencyType 
    { 
        Euro,
        Dollar,
        Yen
    }

 
}
