using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Result;
using MediatR;

namespace Application.Features.User.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<UserDto>> {
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository) {
        _userRepository = userRepository;
    }
    
    public async Task<Result<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken) {
        var user = _userRepository.GetById(request.UserId);
        return user is null
            ? Result.Failure<UserDto>(UserErrors.NotFoundOne)
            : Result.Success(user.MapToDto());
    }
}