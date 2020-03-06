using System;
using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class TransactionCategory
    {
        public TransactionCategory()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int TransactionCategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<Transaction> Transactions { get; private set; }
    }
}
