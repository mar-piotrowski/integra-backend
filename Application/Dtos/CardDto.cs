using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos;

public record CardDto(
    string Number,
    DateTimeOffset AssignmentDate,
    bool Active,
    UserDto User
);