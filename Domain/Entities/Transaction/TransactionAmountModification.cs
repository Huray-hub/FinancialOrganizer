namespace Domain.Entities.Transaction
{
    public class TransactionAmountModification
    {
        public int TransactionId { get; set; }
        public int AmountModificationId { get; set; }

        public Transaction Transaction { get; set; }
        public AmountModification AmountModification { get; set; }
    }
}
