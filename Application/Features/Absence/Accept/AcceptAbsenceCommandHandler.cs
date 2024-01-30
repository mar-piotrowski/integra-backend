using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;

namespace Application.Features.Absence.Accept;

public class AcceptAbsenceCommandHandler : ICommandHandler<AcceptAbsenceCommand> {
    private readonly IAbsenceRepository _absenceRepository;
    private readonly IHolidayLimitRepository _holidayLimitRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AcceptAbsenceCommandHandler(
        IAbsenceRepository absenceRepository,
        IUnitOfWork unitOfWork,
        IHolidayLimitRepository holidayLimitRepository
    ) {
        _absenceRepository = absenceRepository;
        _unitOfWork = unitOfWork;
        _holidayLimitRepository = holidayLimitRepository;
    }

    public async Task<Result> Handle(AcceptAbsenceCommand request, CancellationToken cancellationToken) {
        var absence = _absenceRepository.FindById(request.AbsenceId);
        if (absence is null)
            return Result.Failure(AbsenceErrors.NotFound);
        var status = absence.Status;
        if (status != AbsenceStatus.Pending && status == AbsenceStatus.Accepted)
            return Result.Failure(AbsenceErrors.AlreadyAccepted);
        if (status != AbsenceStatus.Pending && status == AbsenceStatus.Rejected)
            return Result.Failure(AbsenceErrors.AlreadyRejected);
        var limit = _holidayLimitRepository.FindThisYear();
        if (limit is null)
            return Result.Failure(HolidayLimitErrors.NotFound);
        if (!LimitHasAvailableDays(limit, absence))
            return Result.Failure(AbsenceErrors.NoAvailableDays);
        limit.AddUsedDays((absence.EndDate - absence.StartDate).Days);
        absence.Accept();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    private bool LimitHasAvailableDays(Domain.Entities.HolidayLimit limit, Domain.Entities.Absence absence) =>
        limit.UsedDays <= (absence.EndDate - absence.StartDate).Days;
}