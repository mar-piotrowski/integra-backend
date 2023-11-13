using Domain.Common.Models;

namespace Domain.ValueObjects.Ids {
    public class ContractorId : ValueObject {
        public int Value { get; set; }
        private ContractorId(int value) => Value = value;
    
        public static ContractorId Create(int value) => new ContractorId(value);

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Value;
        }
    }
}