using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Enums;
using Domain.Result;

namespace Application.Features.Authentication.Commands;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, TokenResponse> {
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork
    ) {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TokenResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken) {
        var emailExist = _userRepository.GetByEmail(request.Email);
        if (emailExist is not null)
            return Result.Failure<TokenResponse>(UserErrors.EmailNotFound);
        if (request.Password != request.ConfirmPassword)
            return Result.Failure<TokenResponse>(AuthenticationErrors.WrongConfirmPassword);
        var hashPassword = _passwordHasher.Hash(request.Password);
        var user = Domain.Entities.User.Create(request.Firstname, request.Lastname, request.Email);
        // var token = _jwtTokenGenerator.GenerateToken(request.Firstname, request.Lastname);
        user.AddCredentials(Credential.Create(hashPassword, Permission.Administrator));
        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(new TokenResponse(""));
    }
}