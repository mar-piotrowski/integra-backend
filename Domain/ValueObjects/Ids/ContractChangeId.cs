using Domain.Common.Models;

namespace Domain.ValueObjects.Ids;

public class ContractChangeId : ValueObject {
   public int Value { get; private set; }
   
   public ContractChangeId(int value) => Value = value;

   public static ContractChangeId Create(int value) => new ContractChangeId(value);
   
   protected override IEnumerable<object> GetAtomicValues() {
       yield return Value;
   }
}