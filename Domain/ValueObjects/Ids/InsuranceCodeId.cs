using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class InsuranceCodeId : ValueObject {
    public int Value { get; private set; }

    private InsuranceCodeId(int value) => Value = value;

    public static InsuranceCodeId Create(int value) => new InsuranceCodeId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}