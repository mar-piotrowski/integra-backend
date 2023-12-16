using Domain.Common.Models;
using Domain.Enums;

namespace Domain.ValueObjects;

public class Permission : ValueObject {
    public PermissionType Type { get; private set; }

    public Permission(PermissionType type) {
        Type = type;
    }

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Type;
    }
}