using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;

namespace Application.Features.Absence.Reject;

public class RejectAbsenceCommandHandler : ICommandHandler<RejectAbsenceCommand> {
    private readonly IAbsenceRepository _absenceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RejectAbsenceCommandHandler(IAbsenceRepository absenceRepository, IUnitOfWork unitOfWork) {
        _absenceRepository = absenceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RejectAbsenceCommand request, CancellationToken cancellationToken) {
        var absence = _absenceRepository.GetById(request.AbsenceId);
        if (absence is null)
            return Result.Failure(AbsenceErrors.NotFound);
        var status = absence.Status;
        if (status != AbsenceStatus.Pending && status == AbsenceStatus.Accepted)
            return Result.Failure(AbsenceErrors.AlreadyAccepted);
        if (status != AbsenceStatus.Pending && status == AbsenceStatus.Rejected)
            return Result.Failure(AbsenceErrors.AlreadyRejected);
        absence.Reject();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}