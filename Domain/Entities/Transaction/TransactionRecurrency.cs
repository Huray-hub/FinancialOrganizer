using System;

namespace Domain.Entities.Transaction
{
    public class TransactionRecurrency
    {
        public Guid TransactionRecurrencyId { get; set; }
        public decimal Installment { get; set; }
        public int InstallmentsNumber { get; set; }
        public int FrequencyType { get; set; }
        public DateTime EndDate { get; set; }

        public Guid TransactionAmountId { get; set; }
        public TransactionAmount TransactionAmount { get; set; }
    }
}
