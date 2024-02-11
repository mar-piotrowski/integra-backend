using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects;

namespace Application.Features.Authentication.ChangePassword;

public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public ChangePasswordCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork) {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.FindById(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.EmailNotFound);
        if (user.Credential is null)
            return Result.Failure(UserErrors.NoCredentials);
        if (request.NewPassword.Length < 8 || request.CurrentPassword.Length < 8)
            return Result.Failure(UserErrors.PasswordIsTooShort);
        if (!_passwordHasher.Verify(user.Credential.Password, Password.Create(request.CurrentPassword)))
            return Result.Failure(UserErrors.CurrentPasswordDifferent);
        var newPassword = _passwordHasher.Hash(Password.Create(request.NewPassword));
        user.Credential.ChangePassword(newPassword);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}