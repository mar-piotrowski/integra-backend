using System.Runtime.InteropServices.JavaScript;
using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.Create;

public class CreateAbsenceCommandHandler : ICommandHandler<CreateAbsenceCommand> {
    private readonly IAbsenceRepository _absenceRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateAbsenceCommandHandler(
        IAbsenceRepository absenceRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider
    ) {
        _absenceRepository = absenceRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result> Handle(CreateAbsenceCommand request, CancellationToken cancellationToken) {
        if (!DatesAreValid(request.StartDate, request.EndDate))
            return Result.Failure(AbsenceErrors.InvalidDates);
        var user = _userRepository.FindWithAbsences(UserId.Create(request.UserId));
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
        var absence = new Domain.Entities.Absence(
            request.Type,
            request.StartDate,
            request.EndDate,
            request.DiseaseCode,
            request.Series,
            request.Number,
            request.Description
        );
        if (request.Accepted) {
            absence.Accept();
            limit.AddUsedDays(days);
        }

        _absenceRepository.Add(absence);
        user.AddAbsence(absence);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    private Domain.Entities.HolidayLimit? HolidayLimitExists(DateTimeOffset startDate, Domain.Entities.User user) {
        var limit = user.HolidayLimits.FirstOrDefault(limit => limit.StartDate.Year == startDate.Year);
        return limit;
    }

    private bool DatesAreValid(DateTimeOffset startDate, DateTimeOffset endDate) =>
        startDate <= _dateTimeProvider.UtcNow() && startDate <= endDate;
}