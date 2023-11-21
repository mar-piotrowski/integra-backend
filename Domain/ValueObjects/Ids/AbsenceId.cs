using Domain.Common.Models;

namespace Domain.ValueObjects.Ids; 

public class AbsenceId : ValueObject {
    public int Value { get; private set; }

    private AbsenceId(int value) => Value = value;

    public static AbsenceId Create(int value) => new AbsenceId(value);
    
    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}