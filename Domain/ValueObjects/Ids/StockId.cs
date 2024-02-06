using Domain.Common.Models;

namespace Domain.ValueObjects.Ids {
    public class StockId : ValueObject {
        public int Value { get; init; }

        public StockId(int value) => Value = value;

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Value;
        }
    }
}