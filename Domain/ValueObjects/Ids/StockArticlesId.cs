using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class StockArticlesId : ValueObject {
    public readonly int Value;
    
    public StockArticlesId(int value) => Value = value;

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }
}