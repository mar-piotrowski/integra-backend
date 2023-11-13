using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class ContractId : ValueObject {
    public int Value { get; private set; }
    
    private ContractId(int value) => Value = value;

    public static ContractId Create(int value) => new ContractId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}