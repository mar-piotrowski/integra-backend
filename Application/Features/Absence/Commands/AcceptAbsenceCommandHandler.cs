using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Enums;
using Domain.Result;

namespace Application.Features.Absence.Commands;

public class AcceptAbsenceCommandHandler : ICommandHandler<AcceptAbsenceCommand> {
    private readonly IAbsenceRepository _absenceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AcceptAbsenceCommandHandler(IAbsenceRepository absenceRepository, IUnitOfWork unitOfWork) {
        _absenceRepository = absenceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AcceptAbsenceCommand request, CancellationToken cancellationToken) {
        var absence = _absenceRepository.GetByIdWithStatus(request.AbsenceId);
        if (absence is null)
            return Result.Failure(AbsenceErrors.NotFound);
        var status = absence.Status.Status;
        if (status != AbsenceStatus.Pending && status == AbsenceStatus.Accepted)
            return Result.Failure(AbsenceErrors.AlreadyAccepted);
        if (status != AbsenceStatus.Pending && status == AbsenceStatus.Rejected)
            return Result.Failure(AbsenceErrors.AlreadyRejected);
        absence.Accept(request.Description);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}