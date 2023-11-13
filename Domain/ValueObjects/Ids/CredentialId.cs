using Domain.Common.Models;

namespace Domain.ValueObjects.Ids {
    public class CredentialId : ValueObject {
        public int Value { get; set; }

        private CredentialId(int value) =>
            Value = value;

        public static CredentialId Create(int value) => new CredentialId(value);

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Value;
        }
    }
}