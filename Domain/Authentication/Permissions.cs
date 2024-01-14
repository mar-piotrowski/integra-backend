using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Authentication;

public static class Permissions {
    public static readonly List<Permission> WebsitePermissions = new List<Permission>() {
        new Permission(PermissionType.User, "Owner", PermissionCode.Create(748)),
        new Permission(PermissionType.User, "HrAll", PermissionCode.Create(1)),
        new Permission(PermissionType.User, "HrEmployees", PermissionCode.Create(2)),
        new Permission(PermissionType.User, "HrSchedule", PermissionCode.Create(3)),
        new Permission(PermissionType.User, "HrContracts", PermissionCode.Create(4)),
    };
}