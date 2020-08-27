using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class TransactionCategory : BaseEntity
    {
        public TransactionCategory()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string Name { get; set; }

        public ICollection<Transaction> Transactions { get; private set; }
    }
}
