namespace Application.Dtos;

public record GetPermissionsResponse(IEnumerable<PermissionDto> Permissions);