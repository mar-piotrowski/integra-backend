using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class PermissionId : ValueObject {
    public readonly int Value;
    private PermissionId(int value) => Value = value;

    public static PermissionId Create(int value) => new PermissionId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}