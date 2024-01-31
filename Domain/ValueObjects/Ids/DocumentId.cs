using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class DocumentId : ValueObject {
    public int Value { get; private set; }
    private DocumentId(int value) => Value = value;

    public static DocumentId Create(int value) => new DocumentId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}