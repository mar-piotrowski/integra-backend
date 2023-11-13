using Domain.Common.Models;

namespace Domain.Models {
    public class Price : ValueObject {
        public readonly decimal Amount;

        private Price(decimal amount) =>
            Amount = amount;

        public static Price Create(decimal amount) => new Price(amount);

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Amount;
        }
    }
}