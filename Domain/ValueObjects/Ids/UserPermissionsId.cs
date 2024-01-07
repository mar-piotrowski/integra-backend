using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class UserPermissionsId : ValueObject {
    public int Value { get; private set; }

    private UserPermissionsId(int value) => Value = value;

    public static UserPermissionsId Create(int value) => new UserPermissionsId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}