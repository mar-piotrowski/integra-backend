using FluentValidation;

namespace Application.Dtos;

public class UpdateUserRequest {
    public string Firstname { get; init; }
    public string Lastname { get; init; }
    public string? SecondName { get; init; }
    public string Email { get; init; }
    public string? Phone { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public string? PlaceOfBirth { get; init; }
    public string? Sex { get; init; }
    public bool IsStudent { get; init; }
    public List<LocationDto>? Locations { get; init; }
}

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