using Domain.Common.Models;

namespace Domain.ValueObjects;

public class PermissionCode : ValueObject {
    public readonly int Value;
    private PermissionCode(int value) => Value = value;
        
    public static PermissionCode Create(int value) => new PermissionCode(value);
    
    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}