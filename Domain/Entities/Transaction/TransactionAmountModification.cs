using System;

namespace Domain.Entities.Transaction
{
    public class TransactionAmountModification
    {
        public int TransactionAmountId { get; set; }
        public TransactionAmount TransactionAmount { get; set; }

        public int AmountModificationId { get; set; }
        public AmountModification AmountModification { get; set; }
    }
}
