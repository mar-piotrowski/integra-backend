using Domain.Authentication;
using Domain.Entities;

namespace Infrastructure.Seeders;

public class PermissionSeed {
    private readonly DatabaseContext _databaseContext;

    public PermissionSeed(DatabaseContext databaseContext) => _databaseContext = databaseContext;

    public void Seed() {
        _databaseContext.Database.EnsureCreated();
        var permissions = _databaseContext.Set<Permission>().ToList();
        if (HasAllPermissions(permissions))
            return;
        if (!permissions.Any()) EmptyPermissionsTable();
        else NotEmptyPermissionsTable(permissions);
        _databaseContext.SaveChanges();
    }

    private void EmptyPermissionsTable() {
        foreach (var websitePermission in Permissions.WebsitePermissions)
            _databaseContext.Set<Permission>().Add(websitePermission);
    }

    private void NotEmptyPermissionsTable(IReadOnlyCollection<Permission> permissions) {
        foreach (var websitePermission in Permissions.WebsitePermissions)
            if (!permissions.Contains(websitePermission))
                _databaseContext.Set<Permission>().Add(websitePermission);
    }

    private static bool HasAllPermissions(IReadOnlyCollection<Permission> permissions) =>
        Permissions.WebsitePermissions.All(websitePermission =>
            permissions.FirstOrDefault(permission => permission.Code == websitePermission.Code) is not null
        );
}