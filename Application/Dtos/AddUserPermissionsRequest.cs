namespace Application.Dtos;

public record AddUserPermissionsRequest(IEnumerable<int> Permissions);