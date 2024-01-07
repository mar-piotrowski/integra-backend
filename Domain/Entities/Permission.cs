using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Permission : Entity<PermissionId> {
    public PermissionType Type { get; private set; }
    public string Name { get; private set; }
    public PermissionCode Code { get; private set; }
    public IEnumerable<UserPermissions> Permissions { get; private set; }

    public Permission() { }

    public Permission(PermissionType type, string name, PermissionCode code) {
        Type = type;
        Name = name;
        Code = code;
    }
}