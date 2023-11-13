using Domain.Common.Models;

namespace Domain.ValueObjects.Ids {
    public sealed class UserId : ValueObject {
        public int Value { get; private set; }

        private UserId(int value) =>
            Value = value;

        public static UserId Create(int id) => new UserId(id);

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Value;
        }
    }
}