using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class DeductibleCostId : ValueObject {
    public int Value { get; private set; }
    private DeductibleCostId(int value) => Value = value;

    public static DeductibleCostId Create(int value) => new DeductibleCostId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}