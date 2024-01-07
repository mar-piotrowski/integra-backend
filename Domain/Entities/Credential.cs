using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public class Credential : Entity<CredentialId> {
        public string Password { get; private set; }
        private readonly List<Permission> _permissions = new List<Permission>();
        public IReadOnlyList<Permission> Permissions => _permissions.AsReadOnly();
        
        private Credential() { }

        private Credential(string password) => Password = password;

        public static Credential Create(string password) => new Credential(password);

        public void AddPermission(Permission permission) => _permissions.Add(permission);
    }
}