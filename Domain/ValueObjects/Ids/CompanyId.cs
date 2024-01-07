using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class CompanyId : ValueObject {
    public readonly int Value;
    
    private CompanyId(int value) => Value = value;

    public static CompanyId Create(int value) => new CompanyId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}