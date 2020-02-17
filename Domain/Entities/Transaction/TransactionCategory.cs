using System;
using System.Collections.Generic;

namespace Domain
{
    public class TransactionCategory
    {
        public Guid TransactionCategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
