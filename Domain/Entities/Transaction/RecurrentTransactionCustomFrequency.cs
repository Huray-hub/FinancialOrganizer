namespace Domain.Entities.Transaction
{
    public class RecurrentTransactionCustomFrequency : BaseEntity
    {
        public int TimeUnit { get; set; }
        public int TimeUnitQuantity { get; set; }

        public int TransactionRecurrencyId { get; set; }

        public TransactionRecurrency TransactionRecurrency { get; set; }
    }
}
