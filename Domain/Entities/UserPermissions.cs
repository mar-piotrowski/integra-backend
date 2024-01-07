using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class UserPermissions : Entity<UserPermissionsId> {
   public PermissionId PermissionId { get; private set; }
   public UserId UserId { get; private set; }
   public virtual Permission Permission { get; private set; }
   public virtual User User { get; private set; }

   public UserPermissions(UserId userId, PermissionId permissionId) {
      UserId = userId;
      PermissionId = permissionId;
   }
}