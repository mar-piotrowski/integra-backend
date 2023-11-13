using Domain.Common.Models;

namespace Domain.ValueObjects.Ids; 

public class JobPositionId : ValueObject{
    public int Value { get; private set; }

    private JobPositionId(int value) => Value = value;

    public static JobPositionId Create(int value) => new JobPositionId(value);
    
    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}