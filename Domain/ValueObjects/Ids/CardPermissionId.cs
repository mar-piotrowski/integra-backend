using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class CardPermissionId : ValueObject {
    public int Value { get; private set; }
    
    private CardPermissionId() { }

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}