using System;
using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class AmountModificationCategory
    {
        public Guid AmountModificationCategoryId { get; set; }
        public string Title { get; set; }

        public ICollection<AmountModification> AmountModifications { get; set; }
    }
}
