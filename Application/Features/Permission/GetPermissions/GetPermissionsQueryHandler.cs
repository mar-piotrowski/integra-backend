using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Permission.GetPermissions;

public class GetPermissionsQueryHandler : IQueryHandler<GetPermissionsQuery, GetPermissionsResponse> {
    private readonly IPermissionRepository _permissionRepository;

    public GetPermissionsQueryHandler(IPermissionRepository permissionRepository) =>
        _permissionRepository = permissionRepository;

    public async Task<Result<GetPermissionsResponse>> Handle(
        GetPermissionsQuery request,
        CancellationToken cancellationToken
    ) {
        var permissions = _permissionRepository.GetAll(request.Filters).ToList();
        return !permissions.Any()
            ? Result.Failure<GetPermissionsResponse>(PermissionErrors.NotFoundAny)
            : Result.Success(new GetPermissionsResponse(permissions.MapToDtos()));
    }
}