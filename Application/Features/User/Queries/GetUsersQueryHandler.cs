using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Result;
using MediatR;

namespace Application.Features.User.Queries;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<UsersResponse>> {
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository) {
        _userRepository = userRepository;
    }
    
    public async Task<Result<UsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken) {
        var users = _userRepository.GetAllWithLocation();
        if (!users.Any())
            return Result.Failure<UsersResponse>(UserErrors.NotFoundMany);
        return Result.Success<UsersResponse>(users.MapToUsersResponse());
    }
}