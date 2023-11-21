using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Entities {
    public class UserLocation : IAuditableEntity {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Location Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}