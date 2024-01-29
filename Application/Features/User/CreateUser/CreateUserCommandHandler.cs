using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects;

namespace Application.Features.User.CreateUser;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IJobPositionRepository _jobPositionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        IJobPositionRepository jobPositionRepository,
        IUnitOfWork unitOfWork,
        IPermissionRepository permissionRepository
    ) {
        _userRepository = userRepository;
        _jobPositionRepository = jobPositionRepository;
        _unitOfWork = unitOfWork;
        _permissionRepository = permissionRepository;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        if (!string.IsNullOrEmpty(request.Email) && _userRepository.GetByEmail(Email.Create(request.Email)) is not null)
            return Result.Failure<string>(UserErrors.EmailExists);
        if (_userRepository.GetByPersonalIdNumber(PersonalIdNumber.Create(request.IdentityNumber)) is not null)
            return Result.Failure<string>(UserErrors.IdentityNumberExists);
        if (!request.Locations.Any())
            return Result.Failure(UserErrors.NoLocations);
        var user = Domain.Entities.User.Create(
            request.Firstname,
            request.Lastname,
            !string.IsNullOrEmpty(request.Email) ? Email.Create(request.Email) : null,
            PersonalIdNumber.Create(request.IdentityNumber),
            !string.IsNullOrEmpty(request.DocumentNumber) ? DocumentNumber.Create(request.DocumentNumber) : null,
            string.IsNullOrWhiteSpace(request.Phone) ? null : Phone.Create(request.Phone),
            request.SecondName,
            request.IsStudent,
            request.DateOfBirth,
            request.PlaceOfBirth,
            request.Sex
        );
        var employeePermission = _permissionRepository.GetByCode(PermissionCode.Create(112));
        if (employeePermission is not null)
            user.AddPermissions(new List<Domain.Entities.Permission>() { employeePermission });
        user.AddLocations(request.Locations.MapToEntities());
        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}