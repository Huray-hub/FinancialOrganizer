using System;

namespace Domain.Entities.Transaction
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int Currency { get; set; }
        public bool IsRecurrent { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Guid CategoryId { get; set; }
        public TransactionCategory Category { get; set; }

        public TransactionAmount TransactionAmount { get; set; }
    }
}
