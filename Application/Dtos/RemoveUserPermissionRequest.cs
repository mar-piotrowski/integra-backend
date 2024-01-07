namespace Application.Dtos;

public record RemoveUserPermissionRequest(IEnumerable<int> PermissionCodes);