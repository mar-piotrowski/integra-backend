using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Schedule.DeleteSchedule;

public record DeleteScheduleCommand(ScheduleSchemaId ScheduleSchemaId) : ICommand;