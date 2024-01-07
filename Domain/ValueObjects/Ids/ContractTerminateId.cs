using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class ContractTerminateId : ValueObject {
    public int Value { get; set; }
    private ContractTerminateId(int value) => Value = value;

    public static ContractTerminateId Create(int value) => new ContractTerminateId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}