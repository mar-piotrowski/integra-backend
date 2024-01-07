using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using MediatR;

namespace Application.Features.User.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<UserDto>> {
    private readonly IUserRepository _userRepository;
    private readonly UserMapper _userMapper;

    public GetUserQueryHandler(IUserRepository userRepository, UserMapper userMapper) {
        _userRepository = userRepository;
        _userMapper = userMapper;
    }
    
    public async Task<Result<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken) {
        var user = _userRepository.GetById(request.UserId);
        return user is null
            ? Result.Failure<UserDto>(UserErrors.NotFound)
            : Result.Success(_userMapper.MapToDto(user));
    }
}