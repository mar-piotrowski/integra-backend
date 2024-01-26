using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Entities;

namespace Application.Features.Schedule.CreateSchedule;

public class CreateScheduleCommandHandler : ICommandHandler<CreateScheduleCommand> {
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateScheduleCommandHandler(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork) {
        _scheduleRepository = scheduleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateScheduleCommand request, CancellationToken cancellationToken) {
        var schedule = _scheduleRepository.FindByName(request.Name);
        if (schedule is not null)
            return Result.Failure(ScheduleErrors.NameExists);
        if (request.StartDate > request.EndDate)
            return Result.Failure(ScheduleErrors.DatesNotValid);
        if (request.Days.Any(day => (int)day.Day < 0 || (int)day.Day > 7))
            return Result.Failure(ScheduleErrors.NotValidDay);
        if (request.Days.Any(day => day.End <= day.Start))
            return Result.Failure(ScheduleErrors.HourIsZeroOrLess);
        if (request.Days.Distinct().Count() != request.Days.Count || request.Days.Count < 7)
            return Result.Failure(ScheduleErrors.NotValidDaysAmount);
        var days = CreateDays(request.Days);
        var newSchedule = new ScheduleSchema(request.Name, request.StartDate, request.EndDate, days);
        _scheduleRepository.Add(newSchedule);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    private static List<ScheduleSchemaDay> CreateDays(IEnumerable<ScheduleDayDto> days) =>
        days.Select(day => new ScheduleSchemaDay(day.Day, day.Start, day.End)).ToList();
}