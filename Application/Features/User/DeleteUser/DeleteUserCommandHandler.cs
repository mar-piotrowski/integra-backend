using Application.Abstractions;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.User.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result> {
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.FindById(request.Id);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        if (user.Contracts.FirstOrDefault(
                contract => contract.Status
                    is ContractStatus.Active
                    or ContractStatus.Pending) is not null
           ) return Result.Failure(UserErrors.NoResolvedContracts);
        user.DeActivate();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}