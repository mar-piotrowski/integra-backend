using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects;

namespace Application.Features.Permission.CreatePermission;

public class CreatePermissionCommandHandler : ICommandHandler<CreatePermissionCommand> {
    private readonly IPermissionRepository _permissionRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreatePermissionCommandHandler(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork) {
        _permissionRepository = permissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreatePermissionCommand request, CancellationToken cancellationToken) {
        var permissionName = _permissionRepository.GetByName(request.Name);
        if (permissionName is not null)
            return Result.Failure(PermissionErrors.NameExists);
        var permissionCode = _permissionRepository.GetByCode(PermissionCode.Create(request.Code));
        if (permissionCode is not null)
            return Result.Failure(PermissionErrors.CodeExists);
        var permission = new Domain.Entities.Permission(
            request.Type,
            request.Name,
            PermissionCode.Create(request.Code)
        );
        _permissionRepository.Add(permission);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}