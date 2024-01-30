using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;

namespace Application.Features.Absence.Update;

public class UpdateAbsenceCommandHandler : ICommandHandler<UpdateAbsenceCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IAbsenceRepository _absenceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UpdateAbsenceCommandHandler(
        IUserRepository userRepository,
        IAbsenceRepository absenceRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider
    ) {
        _userRepository = userRepository;
        _absenceRepository = absenceRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result> Handle(UpdateAbsenceCommand request, CancellationToken cancellationToken) {
        if (!DatesAreValid(request.StartDate, request.EndDate))
            return Result.Failure(AbsenceErrors.InvalidDates);
        var user = _userRepository.FindWithAbsences(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        var limit = HolidayLimitExists(request.StartDate, user);
        if (limit is null)
            return Result.Failure(UserErrors.NoHolidayLimit);
        var days = (request.EndDate - request.StartDate).Days;
        if (limit.AvailableDays < limit.UsedDays + days)
            return Result.Failure(AbsenceErrors.NoAvailableDays);
        if (limit.AvailableDays == limit.UsedDays)
            return Result.Failure(AbsenceErrors.LimitReached);
        var absence = _absenceRepository.GetById(request.AbsenceId);
        if (absence is null)
            return Result.Failure(AbsenceErrors.NotFound);
        if (absence.Status == AbsenceStatus.Accepted)
            return Result.Failure(AbsenceErrors.AlreadyAccepted);
        if (absence.Status == AbsenceStatus.Rejected)
            return Result.Failure(AbsenceErrors.AlreadyRejected);
        absence.Update(
            request.StartDate,
            request.EndDate,
            request.DiseaseCode,
            request.Series,
            request.Number,
            request.Description
        );
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    private Domain.Entities.HolidayLimit? HolidayLimitExists(DateTimeOffset startDate, Domain.Entities.User user) {
        var limit = user.HolidayLimits.FirstOrDefault(limit => limit.StartDate.Year == startDate.Year);
        return limit;
    }

    private bool DatesAreValid(DateTimeOffset startDate, DateTimeOffset endDate) =>
        startDate >= _dateTimeProvider.UtcNow() && startDate < endDate;
}