using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class AmountModification
    {
        public AmountModification()
        {
            TransactionAmountModifications = new HashSet<TransactionAmountModification>();
            RecurrentTransactionSumAmountModifications = new HashSet<RecurrentTransactionSumAmountModification>();
        }

        public int AmountModificationId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public int AmountType { get; set; }
        public int AmountCalculationType { get; set; }


        public ICollection<TransactionAmountModification> TransactionAmountModifications { get; private set; }
        public ICollection<RecurrentTransactionSumAmountModification> RecurrentTransactionSumAmountModifications { get; private set; }
    }  
}
