using Domain.Common.Models;

namespace Domain.ValueObjects.Ids {
    public class BankDetails : ValueObject {
        public string Name { get; private set; }
        public string Number { get; private set; }

        private BankDetails() { }

        private BankDetails(string name, string number) {
            Name = name;
            Number = number;
        }

        public static BankDetails Create(string name, string number) =>
            new BankDetails(name, number);

        public void Update(string name, string number) {
            Name = name;
            Number = number;
        }

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Name;
            yield return Number;
        }
    }
}