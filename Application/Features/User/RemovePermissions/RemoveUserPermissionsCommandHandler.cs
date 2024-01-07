using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects;

namespace Application.Features.User.RemovePermissions;

public class RemoveUserPermissionsCommandHandler : ICommandHandler<RemoveUserPermissionsCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveUserPermissionsCommandHandler(
        IUserRepository userRepository,
        IPermissionRepository permissionRepository,
        IUnitOfWork unitOfWork
    ) {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _permissionRepository = permissionRepository;
    }

    public async Task<Result> Handle(RemoveUserPermissionsCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetById(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        var verifyPermissionsResult = VerifyPermissionsToDelete(user, request.PermissionCodes);
        if (verifyPermissionsResult.IsFailure)
            return verifyPermissionsResult;
        var permissions = new List<Domain.Entities.Permission>();
        foreach (var permissionCode in request.PermissionCodes) {
            var permission = _permissionRepository.GetByCode(permissionCode);
            if (permission is null)
                return Result.Failure(PermissionErrors.NotFound);
            permissions.Add(permission);
        }

        user.RemovePermissions(permissions);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    private Result VerifyPermissionsToDelete(Domain.Entities.User user, IEnumerable<PermissionCode> permissions) {
        if (!user.Permissions.Any())
            return Result.Failure(UserErrors.NoPermissions);
        foreach (var permissionCode in permissions)
            if (user.Permissions.FirstOrDefault(permission => permission.Permission.Code == permissionCode) is null)
                return Result.Failure(UserErrors.NoPermission);
        return Result.Success();
    }
}