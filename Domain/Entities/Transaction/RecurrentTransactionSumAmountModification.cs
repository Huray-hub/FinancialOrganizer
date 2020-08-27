namespace Domain.Entities.Transaction
{
    public class RecurrentTransactionSumAmountModification
    {
        public int RecurrentTransactionLimitationId { get; set; }
        public int AmountModificationId { get; set; }

        public RecurrentTransactionLimitation RecurrentTransactionLimitation { get; set; }
        public AmountModification AmountModification { get; set; }
    }
}
