using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Contractor : Entity<ContractorId> {
    public string FullName { get; private set; }
    public string ShortName { get; private set; }
    public string Representative { get; private set; }
    public Email Email { get; private set; }
    public Nip Nip { get; private set; }
    public Phone Phone { get; private set; }
    public Location Location { get; private set; }
    public BankAccount BankAccount { get; private set; }
    public bool Active { get; private set; } = true;
    public bool Historical { get; private set;  }
        
    private Contractor() { }

    private Contractor(
        string fullName,
        string shortName,
        string representative,
        Nip nip,
        Email email,
        Phone phone,
        Location location,
        BankAccount bankAccount
    ) {
        FullName = fullName;
        ShortName = shortName;
        Representative = representative;
        Nip = nip;
        Phone = phone;
        Email = email;
        Location = location;
        BankAccount = bankAccount;
    }

    public static Contractor Create(
        string fullName,
        string shortName,
        string representative,
        Nip nip,
        Email email,
        Phone phone,
        Location location,
        BankAccount bankAccount
    ) => new Contractor(fullName, shortName, representative, nip, email, phone, location, bankAccount);

    public void Update(string fullName, string shortName, Email email, Phone phone) {
        FullName = fullName;
        ShortName = shortName;
        Email = email;
        Phone = phone;
    }
    
    public void Disable() {
        Active = false;
        Historical = true;
    }
}