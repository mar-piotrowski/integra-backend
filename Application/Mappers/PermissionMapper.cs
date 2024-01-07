using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class PermissionMapper {
    public static PermissionDto MapToDto(this Permission permission) =>
        new PermissionDto(permission.Type, permission.Name, permission.Code.Value);

    public static IEnumerable<PermissionDto> MapToDtos(this IEnumerable<Permission> permissions) =>
        permissions.Select(permission => permission.MapToDto());
}