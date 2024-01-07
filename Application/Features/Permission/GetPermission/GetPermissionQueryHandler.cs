using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Permission.GetPermission;

public class GetPermissionQueryHandler : IQueryHandler<GetPermissionQuery, PermissionDto> {
    private readonly IPermissionRepository _permissionRepository;

    public GetPermissionQueryHandler(IPermissionRepository permissionRepository) {
        _permissionRepository = permissionRepository;
    }

    public async Task<Result<PermissionDto>> Handle(GetPermissionQuery request, CancellationToken cancellationToken) {
        var permission = _permissionRepository.GetByCode(request.Code);
        return permission is null
            ? Result.Failure<PermissionDto>(PermissionErrors.NotFound)
            : permission.MapToDto();
    }
}