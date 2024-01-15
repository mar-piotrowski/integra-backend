using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class BankAccount : Entity<BankAccountId> {
    public string Name { get; private set; }
    public string Number { get; private set; }

    private BankAccount() { }

    public BankAccount(string name, string number) {
        Name = name;
        Number = number;
    }

    public void Update(string name, string number) {
        Name = name;
        Number = number;
    }
}