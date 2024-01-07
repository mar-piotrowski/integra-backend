using Domain.Enums;

namespace Application.Dtos;

public record CreatePermissionRequest(PermissionType Type, string Name, int Code);
