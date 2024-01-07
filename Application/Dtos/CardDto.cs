using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos;

public record CardDto(
    string Number,
    bool IsActive,
    List<Permission> Permissions,
    UserDto User
);