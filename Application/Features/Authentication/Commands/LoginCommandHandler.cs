using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Result;
using MediatR;

namespace Application.Features.Authentication.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponse>> {
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator
    ) {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetByEmail(request.Email);
        if (user is null)
            return Result.Failure<LoginResponse>(UserErrors.EmailNotFound);
        if (!_passwordHasher.Verify(user.Credential.Password, request.Password))
            return Result.Failure<LoginResponse>(UserErrors.PasswordWrong);
        // var token = _jwtTokenGenerator.GenerateToken(user.Firstname, user.Lastname);
        return Result.Success(new LoginResponse(""));
    }
}