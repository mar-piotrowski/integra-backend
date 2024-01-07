using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.User.AddPermission;

public class AddUserPermissionCommandHandler : ICommandHandler<AddUserPermissionCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddUserPermissionCommandHandler(
        IUserRepository userRepository,
        IPermissionRepository permissionRepository,
        IUnitOfWork unitOfWork
    ) {
        _userRepository = userRepository;
        _permissionRepository = permissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddUserPermissionCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetById(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        var permission = _permissionRepository.GetByCode(request.PermissionCode);
        if (permission is null)
            return Result.Failure(PermissionErrors.NotFound);
        user.AddPermission(permission.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}