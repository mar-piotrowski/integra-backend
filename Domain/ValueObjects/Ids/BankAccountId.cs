using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class BankAccountId : ValueObject {
    public string Value { get; }

    private BankAccountId(string value) => Value = value;

    public static BankAccountId Create(string value) => new BankAccountId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}