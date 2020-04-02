using System;

namespace Domain.Entities.Common
{
    public class AuditedEntity
    {
        public string CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
