using Domain.Common.Result;
using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.Dtos;

public record EditUserRequest(
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

public class UpdateUserRequestValidator : AbstractValidator<CreateUserRequest> {
    public UpdateUserRequestValidator() {
        RuleFor(x => x.Firstname)
            .NotEmpty()
            .NotNull();
        RuleFor(x => x.Lastname)
            .NotEmpty()
            .NotNull();
        RuleFor(x => x.SecondName)
            .Null();
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.DateOfBirth)
            .Null();
        RuleFor(x => x.PlaceOfBirth)
            .Null();
        RuleFor(x => x.Sex)
            .Null();
        RuleFor(x => x.IsStudent)
            .NotNull();
    }
}