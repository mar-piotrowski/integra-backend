using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Schedule.UpdateSchedule;

public class UpdateScheduleCommandHandler : ICommandHandler<UpdateScheduleCommand> {
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateScheduleCommandHandler(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork) {
        _scheduleRepository = scheduleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken) {
        var schedule = _scheduleRepository.FindById(request.Id);
        if (schedule is null)
            return Result.Failure(ScheduleErrors.NotFound);
        if (schedule.StartDate > request.EndDate)
            return Result.Failure(ScheduleErrors.DatesNotValid);
        if (request.Days.Any(day => (int)day.Day < 0 || (int)day.Day > 7))
            return Result.Failure(ScheduleErrors.NotValidDay);
        if (request.Days.Any(day => day.EndDate <= day.StartDate))
            return Result.Failure(ScheduleErrors.HourIsZeroOrLess);
        if (request.Days.Distinct().Count() != request.Days.Count || request.Days.Count < 7)
            return Result.Failure(ScheduleErrors.NotValidDaysAmount);
        schedule.Update(request.Name, request.StartDate, request.EndDate);
        
        foreach (var requestDay in request.Days) {
            var currentDay = schedule.Days.FirstOrDefault(day => day.Day == requestDay.Day);
            currentDay?.ChangeHours(requestDay.StartDate, requestDay.EndDate);
        } 

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}