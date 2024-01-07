using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Repositories;

public class UserPermissionsRepository : Repository<UserPermissions, UserPermissionsId>, IUserPermissionsRepository {
    public UserPermissionsRepository(DatabaseContext dbContext) : base(dbContext) { }
}