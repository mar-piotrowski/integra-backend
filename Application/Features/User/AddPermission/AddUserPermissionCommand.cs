using Application.Abstractions.Messaging;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.User.AddPermission;

public record AddUserPermissionCommand(UserId UserId, PermissionCode PermissionCode) : ICommand;