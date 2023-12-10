using Application.Dtos;
using Domain.Result;
using Domain.ValueObjects.Ids;
using MediatR;

namespace Application.Features.User.Commands;

public sealed record CreateUserCommand(
    string Firstname,
    string Lastname,
    string? SecondName,
    string Email,
    string? Phone,
    string IdentityNumber,
    int JobPositionId,
    DateTime? DateOfBirth,
    string? PlaceOfBirth,
    string? Sex,
    bool IsStudent,
    IEnumerable<LocationDto>? Locations
) : IRequest<Result<string>>;