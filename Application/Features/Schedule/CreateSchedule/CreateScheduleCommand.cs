using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Schedule.CreateSchedule;

public record CreateScheduleCommand(
    string Name,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate,
    List<ScheduleDayDto> Days
) : ICommand;