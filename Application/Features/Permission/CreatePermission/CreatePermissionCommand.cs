using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Features.Permission.CreatePermission;

public record CreatePermissionCommand(
    PermissionType Type,
    string Name,
    int Code
) : ICommand;