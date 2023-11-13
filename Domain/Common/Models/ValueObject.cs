namespace Domain.Common.Models {
    public abstract class ValueObject : IEquatable<ValueObject> {

        public static bool operator ==(ValueObject? a, ValueObject? b) {
            if (a is null && b is null)
                return true;
            if (a is null || b is null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b) => !(a == b);

        public bool Equals(ValueObject? other) =>
            other is not null && GetAtomicValues().SequenceEqual(other.GetAtomicValues());

        public override bool Equals(object? obj) {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            return obj is ValueObject valueObject && GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
        }

        public override int GetHashCode() =>
            GetAtomicValues().Aggregate(default(int), HashCode.Combine);

        protected abstract IEnumerable<object> GetAtomicValues();
    }
}