namespace Domain.Entities.Transaction
{
    public class RecurrentTransactionCustomFrequency
    {
        public int RecurrentTransactionCustomFrequencyId { get; set; }
        public int TimeUnit { get; set; }
        public int TimeUnitQuantity { get; set; }

        public int TransactionRecurrencyId { get; set; }
        public TransactionRecurrency TransactionRecurrency { get; set; }
    }
}
