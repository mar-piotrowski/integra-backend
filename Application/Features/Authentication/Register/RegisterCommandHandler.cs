using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Features.Authentication.Register;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, TokenResponse> {
    private readonly IUserRepository _userRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IPermissionRepository permissionRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService,
        IUnitOfWork unitOfWork
    ) {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _permissionRepository = permissionRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<Result<TokenResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken) {
        var emailExist = _userRepository.GetByEmail(request.Email);
        if (emailExist is not null)
            return Result.Failure<TokenResponse>(UserErrors.EmailExists);
        if (request.Password != request.ConfirmPassword)
            return Result.Failure<TokenResponse>(AuthenticationErrors.WrongConfirmPassword);
        var hashPassword = _passwordHasher.Hash(request.Password);
        var user = Domain.Entities.User.Register(request.Firstname, request.Lastname, request.Email);
        user.AddCredentials(Credential.Create(hashPassword));
        user.AddPermissions(_permissionRepository.GetManagementPermissions());
        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(new TokenResponse(_jwtService.GenerateAccessToken(user)));
    }
}