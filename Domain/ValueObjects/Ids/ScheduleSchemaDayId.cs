using Domain.Common.Models;

namespace Domain.ValueObjects.Ids; 

public class ScheduleSchemaDayId : ValueObject {
    public int Value { get; private set; }

    private ScheduleSchemaDayId(int value) => Value = value;

    public static ScheduleSchemaDayId Create(int value) => new ScheduleSchemaDayId(value);
    
    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}