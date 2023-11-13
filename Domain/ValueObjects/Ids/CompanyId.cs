using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class CompanyId : ValueObject {
    public int Value { get; private set; }
    
    private CompanyId(int value) => Value = value;

    public static CompanyId Create(int value) => new CompanyId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        throw new NotImplementedException();
    }
}