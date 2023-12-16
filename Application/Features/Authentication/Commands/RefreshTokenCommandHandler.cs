using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.Authentication.Commands;

public class RefreshTokenCommandHandler : ICommandHandler<RefreshTokenCommand, Tokens> {
    private readonly IJwtService _jwtService;
    private readonly IUserRepository _userRepository;

    public RefreshTokenCommandHandler(
        IJwtService jwtService,
        IUserRepository userRepository
    ) {
        _jwtService = jwtService;
        _userRepository = userRepository;
    }

    public async Task<Result<Tokens>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken) {
        var userId = _jwtService.DecodeJToken(request.Token);
        if (userId is null)
            return Result.Failure<Tokens>(AuthenticationErrors.TokenIsNotValid);
        var user = _userRepository.GetById(userId);
        if (user is null)
            return Result.Failure<Tokens>(UserErrors.NotFound);
        if (user.RefreshToken != request.Token || !_jwtService.IsValid(request.Token))
            return Result.Failure<Tokens>(AuthenticationErrors.TokenIsNotValid);
        var accessToken = _jwtService.GenerateAccessToken(user);
        return Result.Success(new Tokens(accessToken, request.Token));
    }
}