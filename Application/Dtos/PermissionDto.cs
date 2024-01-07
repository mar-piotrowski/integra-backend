using Domain.Enums;

namespace Application.Dtos;

public record PermissionDto(
    PermissionType Type,
    string Name,
    int Code
);