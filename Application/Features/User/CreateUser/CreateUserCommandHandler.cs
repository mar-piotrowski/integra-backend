using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Features.User.CreateUser;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPermissionRepository permissionRepository,
        IPasswordHasher passwordHasher
    ) {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _permissionRepository = permissionRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        if (!string.IsNullOrEmpty(request.Email) && _userRepository.GetByEmail(Email.Create(request.Email)) is not null)
            return Result.Failure<string>(UserErrors.EmailExists);
        if (_userRepository.GetByPersonalIdNumber(PersonalIdNumber.Create(request.IdentityNumber)) is not null)
            return Result.Failure<string>(UserErrors.IdentityNumberExists);
        if (!request.Locations.Any())
            return Result.Failure(UserErrors.NoLocations);
        var user = new Domain.Entities.User(
            request.Firstname,
            request.Lastname,
            !string.IsNullOrEmpty(request.Email) ? Email.Create(request.Email) : null,
            PersonalIdNumber.Create(request.IdentityNumber),
            !string.IsNullOrEmpty(request.DocumentNumber) ? DocumentNumber.Create(request.DocumentNumber) : null,
            string.IsNullOrWhiteSpace(request.Phone) ? null : Phone.Create(request.Phone),
            request.IsStudent,
            request.SecondName,
            request.DateOfBirth,
            request.PlaceOfBirth,
            request.Sex,
            request.Citizenship,
            request.Nip
        );
        var userPermission = _permissionRepository.GetByCode(PermissionCode.Create(943));
        if (userPermission is not null)
            user.AddPermissions(new List<Domain.Entities.Permission>() { userPermission });
        user.AddLocations(request.Locations.MapToEntities());
        user.AddBankAccount(request.BankAccount.Name, request.BankAccount.Number);
        if (!string.IsNullOrWhiteSpace(request.EmployeeAnyWherePassword)) {
            var passwordHashed = _passwordHasher.Hash(Password.Create(request.EmployeeAnyWherePassword));
            user.AddCredentials(Credential.Create(passwordHashed));
        }
        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}