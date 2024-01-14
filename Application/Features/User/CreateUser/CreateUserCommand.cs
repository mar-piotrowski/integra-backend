using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.Enums;

namespace Application.Features.User.CreateUser;

public sealed record CreateUserCommand(
    string Firstname,
    string Lastname,
    string? SecondName,
    string? Email,
    string? Phone,
    string IdentityNumber,
    string? DocumentNumber,
    int JobPositionId,
    DateTime DateOfBirth,
    string PlaceOfBirth,
    Sex Sex,
    bool IsStudent,
    IEnumerable<LocationDto> Locations,
    bool AutoGenerateId
) : ICommand;