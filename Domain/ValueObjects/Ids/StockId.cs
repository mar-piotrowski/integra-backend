using Domain.Common.Models;

namespace Domain.ValueObjects.Ids {
    public class StockId : ValueObject {
        public int Value { get; init; }

        private StockId(int value) =>
            Value = value;

        public static StockId Create(int value) => new StockId(value);

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Value;
        }
    }
}