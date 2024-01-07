using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Permission.GetPermissions;

public record GetPermissionsQuery(PermissionQueryParams Filters) : IQuery<GetPermissionsResponse>;