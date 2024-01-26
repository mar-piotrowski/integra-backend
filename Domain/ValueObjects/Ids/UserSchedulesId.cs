using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class UserSchedulesId
    : ValueObject {
    public int Value { get; private set; }

    private UserSchedulesId(int value) => Value = value;

    public static UserSchedulesId Create(int value) => new UserSchedulesId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}