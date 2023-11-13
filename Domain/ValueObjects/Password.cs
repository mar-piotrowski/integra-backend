using Domain.Common.Models;

namespace Domain.ValueObjects;

public class Password : ValueObject {
    public string Value { get; private set; } = null!;

    public Password() { }
    private Password(string value) => Value = value;

    public static Password Create(string value) => new Password(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}