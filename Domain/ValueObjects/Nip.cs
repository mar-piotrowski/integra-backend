using Domain.Common.Models;

namespace Domain.ValueObjects {
    public class Nip : ValueObject {
        public string Value { get; }
    
        public Nip() { }
        private Nip(string value) => Value = value;

        public static Nip Create(string value) => new Nip(value);

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Value;
        }
    }
}