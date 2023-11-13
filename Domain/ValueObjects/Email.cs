using Domain.Common.Models;

namespace Domain.ValueObjects;

public class Email : ValueObject {
    public string Value { get; private set; }
    
    private Email() { }

    private Email(string value) => Value = value;

    public static Email Create(string value) => new Email(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}