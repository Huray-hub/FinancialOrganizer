using System;

namespace Domain.Entities.Transaction
{
    public class TransactionAmountModification
    {
        public Guid TransactionAmountId { get; set; }
        public TransactionAmount TransactionAmount { get; set; }

        public Guid AmountModificationId { get; set; }
        public AmountModification AmountModification { get; set; }
    }
}
