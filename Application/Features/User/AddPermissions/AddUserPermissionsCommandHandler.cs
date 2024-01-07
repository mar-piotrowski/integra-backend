using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.User.AddPermissions;

public class AddUserPermissionsCommandHandler : ICommandHandler<AddUserPermissionsCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddUserPermissionsCommandHandler(
        IUserRepository userRepository,
        IPermissionRepository permissionRepository,
        IUnitOfWork unitOfWork
    ) {
        _userRepository = userRepository;
        _permissionRepository = permissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddUserPermissionsCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetById(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        var permissionIds = new List<PermissionId>();
        foreach (var permissionCode in request.PermissionCodes) {
            var permission = _permissionRepository.GetByCode(permissionCode);
            if (permission is null)
                return Result.Failure(PermissionErrors.NotFound);
            permissionIds.Add(permission.Id);
        }
        user.AddPermissions(permissionIds);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}