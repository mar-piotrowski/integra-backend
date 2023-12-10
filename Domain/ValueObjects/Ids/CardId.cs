using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class CardId : ValueObject {
    public int Value { get; set; }
    private CardId(int value) => Value = value;
    
    public static CardId Create(int value) => new CardId(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}