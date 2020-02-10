using System;

namespace Domain
{
    public class TransactionCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Transaction Transaction { get; set; }
    }
}
