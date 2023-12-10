using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class HolidayLimitId : ValueObject {
    public int Value { get; set; }
    private HolidayLimitId(int value) => Value = value;
    public static HolidayLimitId Create(int value) => new HolidayLimitId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}