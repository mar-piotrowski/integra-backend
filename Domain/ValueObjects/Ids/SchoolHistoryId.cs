using Domain.Common.Models;

namespace Domain.ValueObjects.Ids; 

public class SchoolHistoryId : ValueObject {
    public int Value { get; private set; }
    private SchoolHistoryId(int value) => Value = value;
    
    public static SchoolHistoryId Create(int value) => new SchoolHistoryId(value);
    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}