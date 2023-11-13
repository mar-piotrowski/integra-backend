using Domain.Abstractions;

namespace Domain.Entities {
    public class TaxRelief : IAuditableEntity {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}