using Application.Abstractions.Messaging;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.User.RemovePermissions;

public record RemoveUserPermissionsCommand(UserId UserId, IEnumerable<PermissionCode> PermissionCodes) : ICommand;