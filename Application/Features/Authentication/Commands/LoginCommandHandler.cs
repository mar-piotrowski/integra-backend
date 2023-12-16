using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Result;
using MediatR;

namespace Application.Features.Authentication.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<Tokens>> {
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService
    ) {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<Result<Tokens>> Handle(LoginCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetByEmail(request.Email);
        if (user is null)
            return Result.Failure<Tokens>(UserErrors.EmailNotFound);
        if (!_passwordHasher.Verify(user.Credential.Password, request.Password))
            return Result.Failure<Tokens>(UserErrors.PasswordWrong);
        var accessToken = _jwtService.GenerateAccessToken(user);
        var refreshToken = _jwtService.GenerateRefreshToken(user);
        return Result.Success(new Tokens(accessToken, refreshToken));
    }
}