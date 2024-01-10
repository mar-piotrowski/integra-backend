using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Credential : Entity<CredentialId> {
    public string Password { get; private set; }
    private Credential() { }

    private Credential(string password) => Password = password;

    public static Credential Create(string password) => new Credential(password);
}