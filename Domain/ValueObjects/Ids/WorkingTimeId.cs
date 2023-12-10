using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class WorkingTimeId : ValueObject{
    public int Value { get; private set; }
    private WorkingTimeId(int value) => Value = value;

    public static WorkingTimeId Create(int value) => new WorkingTimeId(value);
    
    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}