using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;
public class DocumentProductsId : ValueObject {
    public int Value { get; private set; }
    private DocumentProductsId (int value) => Value = value;

    public static DocumentProductsId Create(int value) => new DocumentProductsId (value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}
