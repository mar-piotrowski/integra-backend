using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using MediatR;

namespace Application.Features.User.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<UsersResponse>> {
    private readonly IUserRepository _userRepository;
    private readonly UserMapper _userMapper;
    public GetUsersQueryHandler(IUserRepository userRepository, UserMapper userMapper) {
        _userRepository = userRepository;
        _userMapper = userMapper;
    }
    
    public async Task<Result<UsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken) {
        var users = _userRepository.GetAllWithLocation().ToList();
        if (!users.Any())
            return Result.Failure<UsersResponse>(UserErrors.NotFoundMany);
        return Result.Success<UsersResponse>(_userMapper.MapToUsersResponse(users));
    }
}