using System;

namespace CaWorkshop.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedUtc { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedUtc { get; set; }
    }
}