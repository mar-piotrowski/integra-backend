using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class UserContractsId : ValueObject {
    public int Value { get; private set; }
    
    private UserContractsId(int value) => Value = value;

    public static UserContractsId Create(int value) => new UserContractsId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}