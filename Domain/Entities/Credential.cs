using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.Entities {
    public class Credential : Entity<CredentialId> {
        public string Password { get; private set; }
        public Permission Permission { get; private set; }
        // public List<ModulePermission>? ModulePermissions { get; private set; }

        private Credential() { }

        private Credential(string password, Permission permission) {
            Password = password;
            Permission = permission;
        }

        public static Credential Create(string password, Permission permission) =>
            new Credential(password, permission);
    }
}