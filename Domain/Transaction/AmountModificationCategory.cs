using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AmountModificationCategory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }


        public AmountModification AmountModification { get; set; }
    }
}
