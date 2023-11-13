using Domain.Common.Models;

namespace Domain.ValueObjects.Ids {
    public class OrderId : ValueObject {
        public int Value { get; set; }
        private OrderId(int value) => Value = value;
    
        public static OrderId Create(int value) => new OrderId(value);

        protected override IEnumerable<object> GetAtomicValues() {
            yield return Value;
        }
    }
}