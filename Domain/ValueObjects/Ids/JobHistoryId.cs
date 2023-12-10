using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class JobHistoryId : ValueObject {
    public int Value { get; private set; }
    private JobHistoryId(int value) => Value = value;

    public static JobHistoryId Create(int value) => new JobHistoryId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}