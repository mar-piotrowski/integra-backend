using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;

namespace Application.Features.Absence.Delete;

public class DeleteAbsenceCommandHandler : ICommandHandler<DeleteAbsenceCommand> {
    private readonly IAbsenceRepository _absenceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAbsenceCommandHandler(IAbsenceRepository absenceRepository, IUnitOfWork unitOfWork) {
        _absenceRepository = absenceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAbsenceCommand request, CancellationToken cancellationToken) {
        var absence = _absenceRepository.GetById(request.AbsenceId);
        if (absence is null)
            return Result.Failure(AbsenceErrors.NotFound);
        if (absence.Status == AbsenceStatus.Accepted)
            return Result.Failure(AbsenceErrors.AlreadyAccepted);
        if (absence.Status == AbsenceStatus.Rejected)
            return Result.Failure(AbsenceErrors.AlreadyRejected);
        _absenceRepository.Remove(absence);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}