using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class ScheduleSchemaId : ValueObject {
    public int Value { get; private set; }
    private ScheduleSchemaId(int value) => Value = value;
    public static ScheduleSchemaId Create(int value) => new ScheduleSchemaId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}