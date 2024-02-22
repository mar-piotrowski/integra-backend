using Domain.Common.Models;

namespace Domain.ValueObjects;

public class CardNumber : ValueObject {
    public string Value { get; private set; }

    private CardNumber(string value) => Value = value.ToUpper().Trim();

    public static CardNumber Create(string value) => new CardNumber(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}