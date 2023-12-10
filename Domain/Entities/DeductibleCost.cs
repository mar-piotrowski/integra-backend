using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public class DeductibleCost : Entity<DeductibleCostId> {
        public required string Name { get; set; }
        public required decimal Value { get; set; }
        public required DateTime RowDate { get; set; }
    }
}