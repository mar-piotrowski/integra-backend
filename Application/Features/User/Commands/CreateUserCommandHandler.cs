using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Enums;
using Domain.Result;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.User.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<string>> {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        if (_userRepository.GetByEmail(Email.Create(request.Email)) is not null)
            return Result.Failure<string>(UserErrors.EmailExists);
        if (_userRepository.GetByIdentityNumber(IdentityNumber.Create(request.IdentityNumber)) is not null)
            return Result.Failure<string>(UserErrors.IdentityNumberExists);
        var user = Domain.Entities.User.Create(
            request.Firstname,
            request.Lastname,
            Email.Create(request.Email),
            IdentityNumber.Create(request.IdentityNumber),
            Phone.Create(request.Phone),
            request.SecondName,
            request.IsStudent,
            request.DateOfBirth,
            request.PlaceOfBirth,
            request.Sex
        );
        var credentials = Credential.Create("123", Permission.Employee);
        user.AddCredentials(credentials);
        if (request.Locations is not null)
            user.AddLocations(request.Locations.MapToEntities());
        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("A");
    }
}