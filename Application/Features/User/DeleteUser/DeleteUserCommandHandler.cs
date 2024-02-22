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
        var activeContract = user.Contracts.FirstOrDefault(
            contract => contract.Status
                is ContractStatus.Active
                or ContractStatus.Pending);
        if (activeContract is not null)
            return Result.Failure(UserErrors.NoResolvedContracts);
        var currentAbsence = user.Absences.FirstOrDefault(absence => absence.EndDate >= DateTimeOffset.Now);
        if (currentAbsence is not null)
            return Result.Failure(UserErrors.CurrentAbsence);
        var pendingAbsence = user.Absences.FirstOrDefault(absence => absence.Status == AbsenceStatus.Pending);
        if (pendingAbsence is not null)
            return Result.Failure(UserErrors.PendingAbsence);
        foreach (var userCard in user.Cards)
            userCard.DeActive();
        user.DeActivate();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}