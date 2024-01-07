using Application.Abstractions.Messaging;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.User.AddPermissions;

public record AddUserPermissionsCommand(UserId UserId, IEnumerable<PermissionCode> PermissionCodes) : ICommand;