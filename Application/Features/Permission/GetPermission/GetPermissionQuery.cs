using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects;

namespace Application.Features.Permission.GetPermission;

public record GetPermissionQuery(PermissionCode Code) : IQuery<PermissionDto>;