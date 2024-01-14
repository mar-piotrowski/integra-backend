using Domain.Common.Models;

namespace Domain.ValueObjects;

public class PersonalIdNumber : ValueObject {
    public string Value { get; private set; }

    private PersonalIdNumber() { }

    private PersonalIdNumber(string value) => Value = value;

    public static PersonalIdNumber Create(string value) => new PersonalIdNumber(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}