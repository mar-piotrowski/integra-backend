using Application.Dtos;
using Domain.Result;
using MediatR;

namespace Application.Features.User.Commands;

public record UpdateUserCommand(
    int UserId,
    string Firstname,
    string Lastname,
    string? SecondName,
    string Email,
    string? Phone,
    DateTime? DateOfBirth,
    string? PlaceOfBirth,
    string? Sex,
    bool IsStudent,
    List<LocationDto>? Locations
) : IRequest<Result>;