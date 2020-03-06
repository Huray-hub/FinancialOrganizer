using System.Collections.Generic;

namespace Domain.Entities.Transaction
{
    public class AmountModificationCategory
    {
        public AmountModificationCategory()
        {
            AmountModifications = new HashSet<AmountModification>();
        }

        public int AmountModificationCategoryId { get; set; }
        public string Title { get; set; }

        public ICollection<AmountModification> AmountModifications { get; private set; }
    }
}
