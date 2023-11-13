using Domain.Common.Models;

namespace Domain.ValueObjects;

public class IdentityNumber : ValueObject {
    public string Value { get; private set; }

    private IdentityNumber() { }

    private IdentityNumber(string value) => Value = value;

    public static IdentityNumber Create(string value) => new IdentityNumber(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}