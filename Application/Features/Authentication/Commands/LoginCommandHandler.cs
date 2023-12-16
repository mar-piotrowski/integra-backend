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
    private readonly IUnitOfWork _unitOfWork;
    
    public LoginCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService, IUnitOfWork unitOfWork) {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Tokens>> Handle(LoginCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetByEmail(request.Email);
        if (user is null)
            return Result.Failure<Tokens>(UserErrors.EmailNotFound);
        if (!_passwordHasher.Verify(user.Credential.Password, request.Password))
            return Result.Failure<Tokens>(UserErrors.PasswordWrong);
        var refreshToken = _jwtService.GenerateRefreshToken(user);
        user.AddRefreshToken(refreshToken);
        var accessToken = _jwtService.GenerateAccessToken(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(new Tokens(accessToken, refreshToken));
    }
}