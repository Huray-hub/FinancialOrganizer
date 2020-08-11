using System;
using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class RecurrentTransactionLimitation : BaseEntity
    {
        public RecurrentTransactionLimitation()
        {
            RecurrentTransactionSumAmountModifications = new HashSet<RecurrentTransactionSumAmountModification>();
        }

        public int SumInstallments { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SumAmount { get; set; }
        public decimal? MaxSumAmount { get; set; }

        public int TransactionRecurrencyId { get; set; }

        public TransactionRecurrency TransactionRecurrency { get; set; }
        public ICollection<RecurrentTransactionSumAmountModification> RecurrentTransactionSumAmountModifications { get; private set; }
    }
}
