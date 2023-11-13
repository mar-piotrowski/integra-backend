using Domain.Abstractions;

namespace Domain.Common.Models {
    public class AuditableEntity : IAuditableEntity {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}