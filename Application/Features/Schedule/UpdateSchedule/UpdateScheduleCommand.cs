using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.Schedule.UpdateSchedule;

public record UpdateScheduleCommand(
    ScheduleSchemaId Id,
    string Name,
    DateTime StartDate,
    DateTime? EndDate,
    List<ScheduleDayDto> Days
) : ICommand;