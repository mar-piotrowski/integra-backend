using Domain.Common.Models;

namespace Domain.ValueObjects.Ids {
    public class LocationId : ValueObject {
        public int Value { get; private set; }

        private LocationId(int value) {
            Value = value;
        }

        public static LocationId Create(int value) => new LocationId(value);
    
        protected override IEnumerable<object> GetAtomicValues() {
            yield return Value;
        }
    }
}