using Application.Dtos;
using Domain.Common.Result;
using Domain.Enums;
using Domain.ValueObjects.Ids;
using MediatR;

namespace Application.Features.User.UpdateUser;

public record UpdateUserCommand(
    UserId UserId,
    string Firstname,
    string Lastname,
    string? SecondName,
    string? Email,
    string? Phone,
    string IdentityNumber,
    string? DocumentNumber,
    DateTimeOffset DateOfBirth,
    string PlaceOfBirth,
    Sex Sex,
    bool IsStudent,
    string? Citizenship,
    string? Nip,
    BankAccountDto? BankAccount,
    List<LocationDto>? Locations
) : IRequest<Result>;