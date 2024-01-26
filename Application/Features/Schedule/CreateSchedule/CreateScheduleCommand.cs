using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Schedule.CreateSchedule;

public record CreateScheduleCommand(
    string Name,
    DateTime StartDate,
    DateTime? EndDate,
    List<ScheduleDayDto> Days
) : ICommand;