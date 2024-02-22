using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeders;

public class UserSeed {
    private readonly DatabaseContext _databaseContext;
    private readonly IPasswordHasher _passwordHasher;

    public UserSeed(DatabaseContext databaseContext, IPasswordHasher passwordHasher) {
        _databaseContext = databaseContext;
        _passwordHasher = passwordHasher;
    }

    public void Seed() {
        _databaseContext.Database.EnsureCreated();
        var admin = GetByEmail(Email.Create("admin@integra.com"));
        if (admin is not null)
            return;
        var hashPassword = _passwordHasher.Hash(Password.Create("qwerty1234"));
        var user = User.Register("admin", "admin", Email.Create("admin@integra.com"));
        user.AddCredentials(Credential.Create(hashPassword));
        user.AddPermissions(GetManagementPermissions());
        _databaseContext.Set<User>().Add(user);
        _databaseContext.SaveChanges();
    }

    private User? GetByEmail(Email email) =>
        _databaseContext.Set<User>()
            .Where(u => u.Active)
            .Include(c => c.Credential)
            .Include(p => p.Permissions).ThenInclude(p => p.Permission)
            .FirstOrDefault(user => user.Email == email);

    private List<Permission> GetManagementPermissions() =>
        _databaseContext.Set<Permission>()
            .Where(permission =>
                permission.Code == PermissionCode.Create(748)
                || permission.Code == PermissionCode.Create(643)
            )
            .ToList();
}