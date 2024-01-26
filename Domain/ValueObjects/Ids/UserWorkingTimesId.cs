using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class UserWorkingTimesId : ValueObject {
    public readonly int Value;
    private UserWorkingTimesId(int value) => Value = value;
    
    public static UserWorkingTimesId Create(int value) => new UserWorkingTimesId(value);
    
    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}