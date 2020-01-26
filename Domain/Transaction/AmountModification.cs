using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AmountModification
    {
        public Guid Id { get; set; }        
        public decimal Amount { get; set; }


        public Guid AmountModificationCategoryId { get; set; }
        public AmountModificationCategory AmountModificationCategory { get; set; }

        public IList<TransactionAmountModification> TransactionAmountModifications { get; set; }       
    }

    public enum AdditionalType
    {
        Charge,
        Discount
    }

    
}
