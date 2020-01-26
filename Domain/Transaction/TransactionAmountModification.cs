using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TransactionAmountModification
    {
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public Guid AmountModificationId { get; set; }
        public AmountModification AmountModification { get; set; }
    }
}
