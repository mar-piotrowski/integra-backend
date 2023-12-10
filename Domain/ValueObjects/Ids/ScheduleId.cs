using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class ScheduleId : ValueObject{
    public int Value { get; private set; }
    private ScheduleId(int value) => Value = value;
    public static ScheduleId Create(int value) => new ScheduleId(value);
    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}