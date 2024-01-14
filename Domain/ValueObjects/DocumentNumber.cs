using Domain.Common.Models;

namespace Domain.ValueObjects;

public class DocumentNumber : ValueObject {
    public readonly string Value;

    private DocumentNumber(string value) => Value = value;

    public static DocumentNumber Create(string value) => new DocumentNumber(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}