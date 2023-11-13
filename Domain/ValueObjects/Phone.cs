using Domain.Common.Models;

namespace Domain.ValueObjects;

public class Phone : ValueObject {
    public string? Value { get; private set; }

    public Phone() { }
    private Phone(string? value) => Value = value;

    public static Phone Create(string? value) => new Phone(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}